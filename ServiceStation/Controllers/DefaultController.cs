using NLog;
using ServiceStation.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceStation.Controllers
{
    [Authorize]
    public abstract class DefaultController : Controller
    {
        protected internal IRepository _repository;
        protected internal static Logger logger = LogManager.GetCurrentClassLogger();
    }
}