//------------------------------------------------------------------------------
// The contents of this file are subject to the nopCommerce Public License Version 1.0 ("License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at  http://www.nopCommerce.com/License.aspx. 
// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. 
// See the License for the specific language governing rights and limitations under the License.
// 
// The Original Code is nopCommerce.
// The Initial Developer of the Original Code is NopSolutions.
// All Rights Reserved.
// 
// Contributor(s): _______. 
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NopSolutions.NopCommerce.BusinessLogic;
using NopSolutions.NopCommerce.BusinessLogic.Orders;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.Payment.Methods.PayPal;
using NopSolutions.NopCommerce.BusinessLogic.Payment;
using NopSolutions.NopCommerce.BusinessLogic.Audit;
using NopSolutions.NopCommerce.Common;
using NopSolutions.NopCommerce.BusinessLogic.IoC;
namespace NopSolutions.NopCommerce.Web
{
    public partial class PaypalIPNHandlerPage : BaseNopPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CommonHelper.SetResponseNoCache(Response);

            if (!Page.IsPostBack)
            {
                byte[] param = Request.BinaryRead(Request.ContentLength);
                string strRequest = Encoding.ASCII.GetString(param);
                Dictionary<string, string> values;

                PayPalStandardPaymentProcessor processor = new PayPalStandardPaymentProcessor();
                if (processor.VerifyIPN(strRequest, out values))
                {
                    #region values
                    decimal total = decimal.Zero;
                    try
                    {
                        total = decimal.Parse(values["mc_gross"], new CultureInfo("en-US"));
                    }
                    catch { }

                    string payer_status = string.Empty;
                    values.TryGetValue("payer_status", out payer_status);
                    string payment_status = string.Empty;
                    values.TryGetValue("payment_status", out payment_status);
                    string pending_reason = string.Empty;
                    values.TryGetValue("pending_reason", out pending_reason);
                    string mc_currency = string.Empty;
                    values.TryGetValue("mc_currency", out mc_currency);
                    string txn_id = string.Empty;
                    values.TryGetValue("txn_id", out txn_id);
                    string txn_type = string.Empty;
                    values.TryGetValue("txn_type", out txn_type);
                    string rp_invoice_id = string.Empty;
                    values.TryGetValue("rp_invoice_id", out rp_invoice_id);
                    string payment_type = string.Empty;
                    values.TryGetValue("payment_type", out payment_type);
                    string payer_id = string.Empty;
                    values.TryGetValue("payer_id", out payer_id);
                    string receiver_id = string.Empty;
                    values.TryGetValue("receiver_id", out receiver_id);
                    string invoice = string.Empty;
                    values.TryGetValue("invoice", out invoice);
                    string payment_fee = string.Empty;
                    values.TryGetValue("payment_fee", out payment_fee);

                    #endregion

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Paypal IPN:");
                    foreach (KeyValuePair<string, string> kvp in values)
                    {
                        sb.AppendLine(kvp.Key + ": " + kvp.Value);
                    }

                    PaymentStatusEnum newPaymentStatus = PaypalHelper.GetPaymentStatus(payment_status, pending_reason);
                    sb.AppendLine("New payment status: " + IoCFactory.Resolve<IPaymentService>().GetPaymentStatusName((int)newPaymentStatus));

                    switch (txn_type)
                    {
                        case "recurring_payment_profile_created":
                            //do nothing here
                            break;
                        case "recurring_payment":
                            #region Recurring payment
                            {
                                Guid orderNumberGuid = Guid.Empty;
                                try
                                {
                                    orderNumberGuid = new Guid(rp_invoice_id);
                                }
                                catch
                                {
                                }

                                Order initialOrder = IoCFactory.Resolve<IOrderService>().GetOrderByGuid(orderNumberGuid);
                                if (initialOrder != null)
                                {
                                    var recurringPayments = IoCFactory.Resolve<IOrderService>().SearchRecurringPayments(0, initialOrder.OrderId, null);
                                    foreach (var rp in recurringPayments)
                                    {
                                        switch (newPaymentStatus)
                                        {
                                            case PaymentStatusEnum.Authorized:
                                            case PaymentStatusEnum.Paid:
                                                {
                                                    var recurringPaymentHistory = rp.RecurringPaymentHistory;
                                                    if (recurringPaymentHistory.Count == 0)
                                                    {
                                                        //first payment
                                                        var rph = new RecurringPaymentHistory()
                                                        {
                                                            RecurringPaymentId = rp.RecurringPaymentId,
                                                            OrderId = initialOrder.OrderId,
                                                            CreatedOn = DateTime.UtcNow
                                                        };
                                                        IoCFactory.Resolve<IOrderService>().InsertRecurringPaymentHistory(rph);
                                                    }
                                                    else
                                                    {
                                                        //next payments
                                                        IoCFactory.Resolve<IOrderService>().ProcessNextRecurringPayment(rp.RecurringPaymentId);
                                                        //UNDONE change new order status according to newPaymentStatus
                                                        //UNDONE refund/void is not supported
                                                    }
                                                }
                                                break;
                                        }
                                    }

                                    //IoCFactory.Resolve<IOrderService>().InsertOrderNote(newOrder.OrderId, sb.ToString(), DateTime.UtcNow);
                                    IoCFactory.Resolve<ILogService>().InsertLog(LogTypeEnum.Unknown, "PayPal IPN. Recurring info", new NopException(sb.ToString()));
                                }
                                else
                                {
                                    IoCFactory.Resolve<ILogService>().InsertLog(LogTypeEnum.OrderError, "PayPal IPN. Order is not found", new NopException(sb.ToString()));
                                }
                            }
                            #endregion
                            break;
                        default:
                            #region Standard payment
                            {
                                string orderNumber = string.Empty;
                                values.TryGetValue("custom", out orderNumber);
                                Guid orderNumberGuid = Guid.Empty;
                                try
                                {
                                    orderNumberGuid = new Guid(orderNumber);
                                }
                                catch
                                {
                                }

                                Order order = IoCFactory.Resolve<IOrderService>().GetOrderByGuid(orderNumberGuid);
                                if (order != null)
                                {
                                    IoCFactory.Resolve<IOrderService>().InsertOrderNote(order.OrderId, sb.ToString(), false, DateTime.UtcNow);
                                    switch (newPaymentStatus)
                                    {
                                        case PaymentStatusEnum.Pending:
                                            {
                                            }
                                            break;
                                        case PaymentStatusEnum.Authorized:
                                            {
                                                if (IoCFactory.Resolve<IOrderService>().CanMarkOrderAsAuthorized(order))
                                                {
                                                    IoCFactory.Resolve<IOrderService>().MarkAsAuthorized(order.OrderId);
                                                }
                                            }
                                            break;
                                        case PaymentStatusEnum.Paid:
                                            {
                                                if (IoCFactory.Resolve<IOrderService>().CanMarkOrderAsPaid(order))
                                                {
                                                    IoCFactory.Resolve<IOrderService>().MarkOrderAsPaid(order.OrderId);
                                                }
                                            }
                                            break;
                                        case PaymentStatusEnum.Refunded:
                                            {
                                                if (IoCFactory.Resolve<IOrderService>().CanRefundOffline(order))
                                                {
                                                    IoCFactory.Resolve<IOrderService>().RefundOffline(order.OrderId);
                                                }
                                            }
                                            break;
                                        case PaymentStatusEnum.Voided:
                                            {
                                                if (IoCFactory.Resolve<IOrderService>().CanVoidOffline(order))
                                                {
                                                    IoCFactory.Resolve<IOrderService>().VoidOffline(order.OrderId);
                                                }
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    IoCFactory.Resolve<ILogService>().InsertLog(LogTypeEnum.OrderError, "PayPal IPN. Order is not found", new NopException(sb.ToString()));
                                }
                            }
                            #endregion
                            break;
                    }
                }
                else
                {
                    IoCFactory.Resolve<ILogService>().InsertLog(LogTypeEnum.OrderError, "PayPal IPN failed.", strRequest);
                }
            }
        }

        public override bool AllowGuestNavigation
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this page is tracked by 'Online Customers' module
        /// </summary>
        public override bool TrackedByOnlineCustomersModule
        {
            get
            {
                return false;
            }
        }
    }
}