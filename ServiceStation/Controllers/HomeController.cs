using ServiceStation.Domain.Abstract;
using System;
using System.Web.Mvc;

namespace ServiceStation.Controllers
{
    //[Authorize]
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

        public ActionResult BadAction()
        {
            throw new Exception("You forgot to implement this ACTION!");
        }
    }
}