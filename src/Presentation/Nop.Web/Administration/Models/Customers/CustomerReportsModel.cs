﻿using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Models;

namespace Nop.Admin.Models.Customers
{
    public partial class CustomerReportsModel : BaseNopModel
    {
        public BestCustomersReportModel BestCustomersByOrderTotal { get; set; }
        public BestCustomersReportModel BestCustomersByNumberOfOrders { get; set; }
    }
}