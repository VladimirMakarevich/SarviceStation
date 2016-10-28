using AutoMapper;
using ServiceStation.Domain.Abstract;
using ServiceStation.Domain.Model;
using ServiceStation.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ServiceStation.Controllers
{
    //[Authorize]
    public class CarController : DefaultController
    {
        int PageSize = 20;
        public CarController(IRepository repository)
        {
            _repository = repository;
        }

        #region List Car
        public ActionResult List_Car(int page = 1)
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
        #endregion

        #region Add New Car
        public ActionResult New_Car()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New_Car(CarViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigCar.CreateMapper();
                    RelatedCars context = map.Map<RelatedCars>(model);

                    string src = await _repository.AddCarAsync(context);
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
            return RedirectToAction("List_Car");
        }
        #endregion

        #region Delete Car
        public async Task<ActionResult> Delete_Car(int id)
        {
            var model = await _repository.RelatedCars.FirstOrDefaultAsync(m => m.CarId == id);
            if (model == null)
            {
                return HttpNotFound();
            }

            IMapper map = MappingConfig.MapperConfigCar.CreateMapper();
            CarViewModel context = map.Map<CarViewModel>(model);

            return View(context);
        }

        [HttpPost, ActionName("Delete_Car")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var model = await _repository.RelatedCars.FirstOrDefaultAsync(m => m.CarId == id);
            if (model.RelatedOrder.Count == 0)
            {
                await _repository.DeleteCarAsync(model);
                return RedirectToAction("List_Car", "Car");
            }

            //TODO: add message with error
            return RedirectToAction("Delete");
        }
        #endregion

        #region Modified Car
        public async Task<ActionResult> Modified_Car(int id)
        {
            try
            {
                var model = await _repository.RelatedCars.FirstOrDefaultAsync(m => m.CarId == id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                IMapper map = MappingConfig.MapperConfigCar.CreateMapper();
                CarViewModel context = map.Map<CarViewModel>(model);
                return View(context);
            }
            catch (Exception ex)
            {
                logger.Error("error: {0}", ex.Message);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modified_Car(CarViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigCar.CreateMapper();
                    RelatedCars context = map.Map<RelatedCars>(model);

                    string src = await _repository.ModifeidCarAsync(context);
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
            //TODO: add message
            return RedirectToAction("List_Car");
        }
        #endregion

        #region Details Car
        public async Task<ActionResult> Details_Car(int id)
        {
            try
            {
                var model = await _repository.RelatedCars.FirstOrDefaultAsync(m => m.CarId == id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                IMapper map = MappingConfig.MapperConfigCar.CreateMapper();
                CarViewModel context = map.Map<CarViewModel>(model);
                return View(context);
            }
            catch (Exception ex)
            {
                logger.Error("error: {0}", ex.Message);
            }
            return RedirectToAction("List_Car");
        }
        #endregion

        #region Check Car
        public ActionResult Check_Car()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Result_Car(CheckCarViewModel model)
        {

            IMapper map = MappingConfig.MapperConfigCar.CreateMapper();
            RelatedCars context = map.Map<RelatedCars>(model);

            var result = await _repository.CheckFreeCarAsync(context);

            if (result != null)
            {
                IMapper mapT = MappingConfig.MapperConfigCar.CreateMapper();
                CarViewModel contextT = map.Map<CarViewModel>(result);
                return View(contextT);
            }

            ViewBag.Message = "At your request no results";
            return View();
        }
        #endregion
    }
}