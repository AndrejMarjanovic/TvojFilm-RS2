using Microsoft.AspNetCore.Mvc;
using TvojFilm.Model;
using TvojFilm.Model.Requests;
using TvojFilm.Services;

namespace TvojFilm.Controllers
{
    public class RedateljiController : BaseCRUDController<Model.Redatelji, RedateljiSearchRequest, RedateljiInsertRequest, RedateljiInsertRequest>
    {
        public RedateljiController(ICRUDService<Model.Redatelji, RedateljiSearchRequest, RedateljiInsertRequest, RedateljiInsertRequest> service) : base(service)
        {

        }

    }
}