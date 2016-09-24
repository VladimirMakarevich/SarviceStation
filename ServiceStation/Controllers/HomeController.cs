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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: Home
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