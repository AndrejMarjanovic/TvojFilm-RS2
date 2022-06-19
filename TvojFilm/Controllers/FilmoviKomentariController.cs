using Microsoft.AspNetCore.Mvc;
using TvojFilm.Model;
using TvojFilm.Model.Requests;
using TvojFilm.Services;

namespace TvojFilm.Controllers
{
    public class FilmoviKomentariController : BaseCRUDController<Model.FilmoviKomentari, FilmoviKomentariSearchRequest, FilmoviKomentariInsertRequest, FilmoviKomentariInsertRequest>
    {
        public FilmoviKomentariController(ICRUDService<Model.FilmoviKomentari, FilmoviKomentariSearchRequest, FilmoviKomentariInsertRequest, FilmoviKomentariInsertRequest> service) : base(service)
        {

        }

    }
}