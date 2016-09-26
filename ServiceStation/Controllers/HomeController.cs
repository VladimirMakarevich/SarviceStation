using NLog;
using ServiceStation.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceStation.Controllers
{
    public class HomeController : DefaultController
    {
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                logger.Error("Error HomeController - {0}", ex.Message);
            }

            return View();
        }
    }
}