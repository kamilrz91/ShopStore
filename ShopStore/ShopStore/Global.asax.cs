using ShopStore.Dal.Repository;
using ShopStore.NinjectBinding.Binders;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ShopStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ShopStore.RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<DbContext>(null);
            ModelBinders.Binders.Add(typeof(Cart), new CartBinder());
        }
    }
}
