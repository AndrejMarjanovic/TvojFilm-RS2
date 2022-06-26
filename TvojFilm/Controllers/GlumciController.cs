using Microsoft.AspNetCore.Mvc;
using TvojFilm.Model;
using TvojFilm.Model.Requests;
using TvojFilm.Services;

namespace TvojFilm.Controllers
{
    public class GlumciController : BaseCRUDController<Model.Glumci, GlumciSearchRequest, GlumciInsertRequest, GlumciInsertRequest>
    {
        public GlumciController(ICRUDService<Model.Glumci, GlumciSearchRequest, GlumciInsertRequest, GlumciInsertRequest> service) : base(service)
        {

        }

    }
}