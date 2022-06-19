using Microsoft.AspNetCore.Mvc;
using TvojFilm.Model;
using TvojFilm.Model.Requests;
using TvojFilm.Services;

namespace TvojFilm.Controllers
{
    public class UlogeController : BaseCRUDController<Model.Uloge, UlogeSearchRequest, UlogeInsertRequest, UlogeInsertRequest>
    {
        public UlogeController(ICRUDService<Model.Uloge, UlogeSearchRequest, UlogeInsertRequest, UlogeInsertRequest> service) : base(service)
        {

        }

    }
}