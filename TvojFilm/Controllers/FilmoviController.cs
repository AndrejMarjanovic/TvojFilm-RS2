using Microsoft.AspNetCore.Mvc;
using TvojFilm.Model;
using TvojFilm.Model.Requests;
using TvojFilm.Services;

namespace TvojFilm.Controllers
{
    public class FilmoviController : BaseCRUDController<Model.Filmovi, FilmoviSearchRequest, FilmoviInsertRequest, FilmoviInsertRequest>
    {
        public FilmoviController(ICRUDService<Model.Filmovi, FilmoviSearchRequest, FilmoviInsertRequest, FilmoviInsertRequest> service) : base(service)
        {

        }

    }
}