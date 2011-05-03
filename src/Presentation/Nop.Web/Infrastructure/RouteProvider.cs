﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace Nop.Web.Infrastructure
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            //products
            routes.MapRoute("Product",
                            "product/{productId}/{SeName}",
                            new { controller = "Catalog", action = "Product", SeName = UrlParameter.Optional });

            //catalog
            routes.MapRoute("Category",
                            "category/{categoryId}/{SeName}",
                            new { controller = "Catalog", action = "Category", SeName = UrlParameter.Optional });
            routes.MapRoute("ManufacturerList",
                            "manufacturer/all/",
                            new { controller = "Catalog", action = "ManufacturerAll"});
            routes.MapRoute("Manufacturer",
                            "manufacturer/{manufacturerId}/{SeName}",
                            new { controller = "Catalog", action = "Manufacturer", SeName = UrlParameter.Optional });
        }
        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
