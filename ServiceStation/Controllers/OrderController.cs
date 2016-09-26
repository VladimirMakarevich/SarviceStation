using ServiceStation.Domain.Abstract;
using ServiceStation.Models;
using System.Linq;
using System.Web.Mvc;

namespace ServiceStation.Controllers
{
    public class OrderController : DefaultController
    {
        int PageSize = 20;
        public OrderController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult List(int page = 1)
        {
            OrderListViewModel model = new OrderListViewModel
            {
                Orders = _repository.Order
                .OrderBy(m => m.OrderId)
                .AsEnumerable()
                .Reverse()
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    ContextPerPage = PageSize,
                    TotalContext = _repository.ClientCard.Count()
                }
            };

            return View(model);
        }

        public ActionResult New_Order()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New_Order(CheckViewModel model)
        {
            return View();
        }
    }
}