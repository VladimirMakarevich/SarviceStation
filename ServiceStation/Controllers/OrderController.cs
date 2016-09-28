using AutoMapper;
using ServiceStation.Domain.Abstract;
using ServiceStation.Domain.Model;
using ServiceStation.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ServiceStation.Controllers
{
    [Authorize]
    public class OrderController : DefaultController
    {
        int PageSize = 20;
        public OrderController(IRepository repository)
        {
            _repository = repository;
        }

        #region List Order
        public ActionResult List_Order(int page = 1)
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
        #endregion

        #region New Order
        public async Task<ActionResult> New_Order(int? id, string VIN = null)
        {
            if (id != null)
            {
                var context = await _repository.ClientCard.FirstOrDefaultAsync(m => m.ClientId == id);
                var model = new NewOrderViewModel
                {
                    ClientCard = context
                };
                if (context == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CarId = new SelectList(_repository.RelatedCars, "CarId", "Make");
                return View(model);
            }
            if (VIN != null)
            {
                var car = await _repository.RelatedCars.FirstOrDefaultAsync(m => m.VIN == VIN);
                ViewBag.CarId = new SelectList(_repository.RelatedCars, "CarId", "Make", car.CarId);
                return View();
            }
            ViewBag.CarId = new SelectList(_repository.RelatedCars, "CarId", "Make");

            return View();
        }

        //public async Task<ActionResult> New_Order(int? id, string VIN = null)
        //{
        //    if (id != null)
        //    {
        //        var context = await _repository.ClientCard.FirstOrDefaultAsync(m => m.ClientId == id);
        //        var model = new NewOrderViewModel
        //        {
        //            ClientCard = context,
        //            Order = null,
        //            RelatedCar = null
        //        };
        //        if (context == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(model);
        //    }
        //    if (VIN != null)
        //    {
        //        var context = await _repository.RelatedCars.FirstOrDefaultAsync(m => m.VIN == VIN);
        //        if (context == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        NewOrderViewModel model = new NewOrderViewModel
        //        {
        //            RelatedCar = context,
        //            ClientCard = null,
        //            Order = null
        //        };
        //        return View(model);
        //    }
        //    //var defaultModel = new NewOrderViewModel
        //    //{
        //    //};

        //    return View();

        //ViewBag.CarId = new SelectList(db.RelatedCarsi, "CarId", "Make", orders.CarId);
        //ViewBag.ClientId = new SelectList(db.ClientCardsi, "ClientId", "FirstName", orders.ClientId);
        //}

        //public async Task<ActionResult> New_Order(int id)
        //{
        //    var context = await _repository.ClientCard.FirstOrDefaultAsync(m => m.ClientId == id);
        //    if (context == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    NewOrderViewModel model = new NewOrderViewModel
        //    {
        //        ClientCard = context
        //    };
        //    return View(model);
        //}

        //public async Task<ActionResult> New_Order(string VIN, string Make)
        //{
        //    var context = await _repository.RelatedCars.FirstOrDefaultAsync(m => m.VIN == VIN && m.Make == Make);
        //    if (context == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    NewOrderViewModel model = new NewOrderViewModel
        //    {
        //        RelatedCar = context
        //    };
        //    return View(model);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New_Order(NewOrderViewModel model, int CarId)
        {
            try
                {
                var flag = await _repository.Order.FirstOrDefaultAsync(m => m.Date == model.Order.Date);
                if (flag == null)
                {
                    await CheckClient(model.ClientCard);
                    var tooFlag = await _repository.RelatedCars.FirstOrDefaultAsync(m => m.CarId == CarId);
                    if (tooFlag != null)
                    {
                        model.Order.CarId = CarId;
                        model.Order.ClientId = model.ClientCard.ClientId;

                        IMapper map = MappingConfig.MapperConfigOrder.CreateMapper();
                        Orders context = map.Map<Orders>(model.Order);

                        string src = await _repository.AddOrderAsync(context);
                        if (src != null)
                        {
                            logger.Error(src);
                        }
                    }
                }
                else
                {
                    ViewBag.Message = "Date accupied for this car. Sorry.";
                    return RedirectToAction("New_Order", "Order");
                }
                ModelState.Clear();
            }
            catch (System.Exception ex)
            {
                logger.Error("error: {0}", ex.Message);
                ModelState.Clear();
            }

            return RedirectToAction("List_Order", "Order");
        }

        private async Task<string> CheckClient(ClientCard clientCard)
        {
            var model = _repository.ClientCard.FirstOrDefault(m => m.ClientId == clientCard.ClientId);
            if (model == null)
            {
                try
                {
                    string src = await _repository.AddClientCardAsync(clientCard);
                    if (src != null)
                    {
                        logger.Error(src);
                        return src;
                    }
                }
                catch (System.Exception ex)
                {
                    logger.Error("error: {0}", ex.Message);
                }
            }
            return null;
        }
        #endregion

        #region Details Order
        public async Task<ActionResult> Details_Order(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repository.Order.FirstOrDefaultAsync(m => m.OrderId == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            IMapper map = MappingConfig.MapperConfigOrder.CreateMapper();
            OrderViewModel context = map.Map<OrderViewModel>(model);
            return View(context);
        }
        #endregion

        #region Modified Order
        public async Task<ActionResult> Modified_Order(int? id)
        {

            var model = await _repository.Order.FirstOrDefaultAsync(m => m.OrderId == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            IMapper map = MappingConfig.MapperConfigOrder.CreateMapper();
            OrderViewModel context = map.Map<OrderViewModel>(model);


            ViewBag.CarId = new SelectList(_repository.RelatedCars, "CarId", "Make", context.CarId);
            ViewBag.ClientId = new SelectList(_repository.ClientCard, "ClientId", "FirstName", context.ClientId);
            return View(context);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modified_Order(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigOrder.CreateMapper();
                    Orders context = map.Map<Orders>(model);

                    string src = await _repository.ModifeidOrderAsync(context);
                    if (src != null)
                    {
                        logger.Error(src);
                    }

                    ModelState.Clear();
                }
                catch (System.Exception ex)
                {
                    logger.Error("error: {0}", ex.Message);
                    ModelState.Clear();
                }
            }

            ViewBag.CarId = new SelectList(_repository.RelatedCars, "CarId", "Make", model.CarId);
            ViewBag.ClientId = new SelectList(_repository.ClientCard, "ClientId", "FirstName", model.ClientId);

            return RedirectToAction("List_Order");
        }
        #endregion

        #region Delete Order
        public async Task<ActionResult> Delete_Order(int id)
        {
            var model = await _repository.Order.FirstOrDefaultAsync(m => m.OrderId == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            IMapper map = MappingConfig.MapperConfigOrder.CreateMapper();
            OrderViewModel context = map.Map<OrderViewModel>(model);

            return View(context);
        }

        [HttpPost, ActionName("Delete_Order")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var model = await _repository.Order.FirstOrDefaultAsync(m => m.OrderId == id);
            if (!model.Clients.ClientOrder.Contains(model)
                && !model.Cars.RelatedOrder.Contains(model)
                && model.Date <= DateTime.Now)
            {
                await _repository.DeleteOrderAsync(model);
                return RedirectToAction("List_Order", "Order");
            }

            //TODO: add message with error
            return RedirectToAction("Delete_Order");
        }
        #endregion

        #region Check Order
        public ActionResult Check_Order(CheckOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                IMapper map = MappingConfig.MapperConfigOrder.CreateMapper();
                Orders context = map.Map<Orders>(model);

                var result = _repository.CheckOrderAsync(context);

                if (result != null)
                {
                    return PartialView(result);
                }
            }
            return PartialView();
        }
#endregion
    }
}