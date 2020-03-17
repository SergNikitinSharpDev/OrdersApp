﻿using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using OrdersApp.Config;

namespace OrdersApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            if (string.IsNullOrWhiteSpace(ConfigurationManager.ConnectionStrings["DefaultConnection"]
                ?.ConnectionString))
            {
                throw new ApplicationException("Connection string must not be empty");
            }

            AutofacConfiguration.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            System.Diagnostics.Debug.WriteLine(exception);
        }
    }
}
