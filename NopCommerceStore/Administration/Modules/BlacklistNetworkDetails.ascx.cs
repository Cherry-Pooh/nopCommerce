﻿//------------------------------------------------------------------------------
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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.BusinessLogic.Security;
using NopSolutions.NopCommerce.BusinessLogic.IoC;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class BlacklistNetworkDetailsControl : BaseNopAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    BannedIpNetwork ipNetwork = ctrlBlacklist.SaveBannedIpNetworkInfo();
                    Response.Redirect("BlacklistNetworkDetails.aspx?BannedIpNetworkID=" + ipNetwork.BannedIpNetworkId.ToString());
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                IoCFactory.Resolve<IBlacklistManager>().DeleteBannedIpNetwork(this.BannedIpNetworkId);
                Response.Redirect("Blacklist.aspx");
            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }

        public int BannedIpNetworkId
        {
            get
            {
                return CommonHelper.QueryStringInt("BannedIpNetworkId");
            }
        }
    }
}