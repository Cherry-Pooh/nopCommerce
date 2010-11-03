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
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NopSolutions.NopCommerce.BusinessLogic.Directory;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.BusinessLogic.Warehouses;
using NopSolutions.NopCommerce.BusinessLogic.IoC;
 
namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class WarehouseDetailsControl : BaseNopAdministrationUserControl
    {
        protected Warehouse Save()
        {
            Warehouse warehouse = ctrlWarehouseInfo.SaveInfo();
            return warehouse;
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Warehouse warehouse = Save();
                    Response.Redirect("Warehouses.aspx");
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        protected void SaveAndStayButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Warehouse warehouse = Save();
                    Response.Redirect("WarehouseDetails.aspx?WarehouseID=" + warehouse.WarehouseId.ToString());
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            IoCFactory.Resolve<IWarehouseManager>().MarkWarehouseAsDeleted(this.WarehouseId);

            Response.Redirect("Warehouses.aspx");
        }

        public int WarehouseId
        {
            get
            {
                return CommonHelper.QueryStringInt("WarehouseId");
            }
        }
    }
}