using Microsoft.AspNetCore.Mvc;
using TvojFilm.Model;
using TvojFilm.Model.Requests;
using TvojFilm.Services;

namespace TvojFilm.Controllers
{
    public class FilmoviOcjeneController : BaseCRUDController<Model.FilmoviOcjene, FilmoviOcjeneSearchRequest, FilmoviOcjeneInsertRequest, FilmoviOcjeneInsertRequest>
    {
        public FilmoviOcjeneController(ICRUDService<Model.FilmoviOcjene, FilmoviOcjeneSearchRequest, FilmoviOcjeneInsertRequest, FilmoviOcjeneInsertRequest> service) : base(service)
        {

        }

    }
}