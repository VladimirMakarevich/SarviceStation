using ServiceStation.Domain.Abstract;
using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceStation.Controllers
{
    public class CarController : DefaultController
    {
        int PageSize = 20;
        public CarController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult List(int page = 1)
        {
            CarListViewModel model = new CarListViewModel
            {
                Cars = _repository.RelatedCars
                .OrderBy(m => m.CarId)
                .AsEnumerable()
                .Reverse()
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingView = new ListView
                {
                    ContextPerPage = PageSize,
                    CurrentPage = page,
                    TotalContext = _repository.RelatedCars.Count()
                }
            };
            return View(model);
        }
    }
}