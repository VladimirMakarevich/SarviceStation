using AutoMapper;
using ServiceStation.Domain.Abstract;
using ServiceStation.Domain.Model;
using ServiceStation.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ServiceStation.Controllers
{
    public class ClientController : DefaultController
    {
        int PageSize = 20;
        public ClientController(IRepository repository)
        {
            _repository = repository;
        }

        #region List Client
        public ActionResult List(int page = 1)
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
            if(ModelState.IsValid)
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
            return View();
        }
        #endregion

        #region
        public ActionResult Check(CheckClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                IMapper map = MappingConfig.MapperConfigClient.CreateMapper();
                ClientCard context = map.Map<ClientCard>(model);

                var result = _repository.CheckClientCardAsync(context);

                if (result == null)
                {
                    return View();
                }
            }
            return View();
        }
        #endregion
    }
}