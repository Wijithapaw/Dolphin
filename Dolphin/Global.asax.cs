using Dolphin.App_Start;
using Dolphin.Data;
using Dolphin.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Dolphin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DataContext.Initialize();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom == "IsAuth")
            {
                if (context.Request.IsAuthenticated)
                {
                    return context.User.Identity.Name;
                }
                return null;
            }

            return base.GetVaryByCustomString(context, custom);
        }
    }
}
