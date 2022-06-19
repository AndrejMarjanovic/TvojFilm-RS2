using Microsoft.AspNetCore.Mvc;
using TvojFilm.Model;
using TvojFilm.Model.Requests;
using TvojFilm.Services;

namespace TvojFilm.Controllers
{
    public class DrzaveController : BaseCRUDController<Model.Drzave, DrzaveSearchRequest, DrzaveInsertRequest, DrzaveInsertRequest>
    {
        public DrzaveController(ICRUDService<Model.Drzave, DrzaveSearchRequest, DrzaveInsertRequest, DrzaveInsertRequest> service) : base(service)
        {

        }

    }
}