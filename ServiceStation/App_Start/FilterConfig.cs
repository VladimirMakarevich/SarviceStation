using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace ServiceStation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    #region WatchConfig
    /// <summary>
    /// WatchConfig - use filter for check action method, elapsed time 
    /// </summary>
    public class WatchConfig : ActionFilterAttribute
    {
        private Stopwatch watch;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            watch = new Stopwatch();
            watch.Start();
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            watch.Stop();
            filterContext.HttpContext.Response.Write(String.Format("time action executed = {0}", watch.ElapsedMilliseconds));
            base.OnActionExecuted(filterContext);
        }
    }
    #endregion
}