using Phoneify.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Phoneify
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // TODO: See how to merge user and Phoneify db
            Database.SetInitializer(new PhoneifyDBInitializer());
            Database.SetInitializer<ApplicationDbContext>(null);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
