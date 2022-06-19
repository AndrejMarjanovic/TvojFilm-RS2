using Microsoft.AspNetCore.Mvc;
using TvojFilm.Model;
using TvojFilm.Model.Requests;
using TvojFilm.Services;

namespace TvojFilm.Controllers
{
    public class PrijedloziFilmovaController : BaseCRUDController<Model.PrijedloziFilmova, PrijedloziFilmovaSearchRequest, PrijedloziFilmovaInsertRequest, PrijedloziFilmovaInsertRequest>
    {
        public PrijedloziFilmovaController(ICRUDService<Model.PrijedloziFilmova, PrijedloziFilmovaSearchRequest, PrijedloziFilmovaInsertRequest, PrijedloziFilmovaInsertRequest> service) : base(service)
        {

        }

    }
}