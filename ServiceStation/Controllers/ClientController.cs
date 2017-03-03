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
    [Authorize]
    public class ClientController : DefaultController
    {
        int PageSize = 20;
        public ClientController(IRepository repository)
        {
            _repository = repository;
        }

        #region List Client
        public ActionResult List_Client(int page = 1)
        {
            ClientListViewModel model = new ClientListViewModel
            {
                ClientCards = _repository.ClientCard
                .OrderBy(m => m.ClientId)
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

        #region Add New Client
        public ActionResult New_Client()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New_Client(ClientCardViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigClient.CreateMapper();
                    ClientCard context = map.Map<ClientCard>(model);

                    string src = await _repository.AddClientCardAsync(context);
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
            return RedirectToAction("List_Client","Client");
        }
        #endregion

        #region Delete Client
        public async Task<ActionResult> Delete_Client(int id)
       {
            var model = await _repository.ClientCard.FirstOrDefaultAsync(m => m.ClientId == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            IMapper map = MappingConfig.MapperConfigClient.CreateMapper();
            ClientCardViewModel context = map.Map<ClientCardViewModel>(model);

            return View(context);
        }

        [HttpPost, ActionName("Delete_Client")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var model = await _repository.ClientCard.FirstOrDefaultAsync(m => m.ClientId == id);
            if (model.ClientOrder.Count == 0)
            {
                await _repository.DeleteClientCardAsync(model);
                return RedirectToAction("Client_List", "Client");
            }

            //TODO: add message with error
            return RedirectToAction("Delete_Client");
        }
        #endregion

        #region Modified Client
        public async Task<ActionResult> Modified_Client(int id)
        {
            //TODO: "date time", modified
            try
            {
                var model = await _repository.ClientCard.FirstOrDefaultAsync(m => m.ClientId == id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                IMapper map = MappingConfig.MapperConfigClient.CreateMapper();
                ClientCardModifeidViewModel context = map.Map<ClientCardModifeidViewModel>(model);
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
        public async Task<ActionResult> Modified_Client(ClientCardModifeidViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigClient.CreateMapper();
                    ClientCard context = map.Map<ClientCard>(model);

                    string src = await _repository.ModifeidClientCardAsync(context);
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
            return RedirectToAction("List_Client");
        }
        #endregion

        #region Details Client
        public async Task<ActionResult> Details_Client(int id)
        {
            try
            {
                var model = await _repository.ClientCard.FirstOrDefaultAsync(m => m.ClientId == id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                IMapper map = MappingConfig.MapperConfigClient.CreateMapper();
                ClientCardViewModel context = map.Map<ClientCardViewModel>(model);
                return View(context);
            }
            catch (Exception ex)
            {
                logger.Error("error: {0}", ex.Message);
            }
            return RedirectToAction("List_Client");
        }
        #endregion

        #region Check Client
        public ActionResult Check_Client()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Result_Client(CheckClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                IMapper map = MappingConfig.MapperConfigClient.CreateMapper();
                ClientCard context = map.Map<ClientCard>(model);

                var result = await _repository.CheckClientCardAsync(context);

                if (result != null)
                {
                    IMapper mapT = MappingConfig.MapperConfigClient.CreateMapper();
                    ClientCardViewModel contextT = map.Map<ClientCardViewModel>(result);
                    return View(contextT);
                }
            }

            ViewBag.Message = "At your request no results";
            return View("_Result");
        }
        #endregion
    }
}