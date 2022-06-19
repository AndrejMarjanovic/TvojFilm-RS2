using Microsoft.AspNetCore.Mvc;
using TvojFilm.Model;
using TvojFilm.Model.Requests;
using TvojFilm.Services;

namespace TvojFilm.Controllers
{
    public class KupnjaFilmovaController : BaseCRUDController<Model.KupnjaFilmova, KupnjaFilmovaSearchRequest, KupnjaFilmovaInsertRequest, KupnjaFilmovaInsertRequest>
    {
        public KupnjaFilmovaController(ICRUDService<Model.KupnjaFilmova, KupnjaFilmovaSearchRequest, KupnjaFilmovaInsertRequest, KupnjaFilmovaInsertRequest> service) : base(service)
        {

        }

    }
}