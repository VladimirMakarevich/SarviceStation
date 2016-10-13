﻿using NLog;
using NLog.Common;
using ServiceStation.Controllers;
using ServiceStation.Infrastructure;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ServiceStation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            logger.Info("Applicetion Start.");

            string nlogPath = Server.MapPath("nlog-web.log");
            InternalLogger.LogFile = nlogPath;
            InternalLogger.LogLevel = NLog.LogLevel.Trace;

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundle(BundleTable.Bundles);
            MappingConfig.RegisterMapping();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalFilters.Filters.Add(new WatchConfig());

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }


        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    var httpContext = ((MvcApplication)sender).Context;
        //    var ex = Server.GetLastError();
        //    var status = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;

        //    // Is Ajax request? return json
        //    if (httpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //    {
        //        httpContext.ClearError();
        //        httpContext.Response.Clear();
        //        httpContext.Response.StatusCode = status;
        //        httpContext.Response.TrySkipIisCustomErrors = true;
        //        httpContext.Response.ContentType = "application/json";
        //        httpContext.Response.Write("{ success: false, message: \"Error occured in server.\" }");
        //        httpContext.Response.End();
        //    }
        //    else
        //    {
        //        var currentController = " ";
        //        var currentAction = " ";
        //        var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

        //        if (currentRouteData != null)
        //        {
        //            if (currentRouteData.Values["controller"] != null &&
        //            !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
        //            {
        //                currentController = currentRouteData.Values["controller"].ToString();
        //            }

        //            if (currentRouteData.Values["action"] != null &&
        //            !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
        //            {
        //                currentAction = currentRouteData.Values["action"].ToString();
        //            }
        //        }

        //        var controller = new ErrorController();
        //        var routeData = new RouteData();

        //        httpContext.ClearError();
        //        httpContext.Response.Clear();
        //        httpContext.Response.StatusCode = status;
        //        httpContext.Response.TrySkipIisCustomErrors = true;

        //        routeData.Values["controller"] = "Error";
        //        routeData.Values["action"] = status == 404 ? "NotFound" : "Index";

        //        controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
        //        ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        //    }
        //}
    }
}
