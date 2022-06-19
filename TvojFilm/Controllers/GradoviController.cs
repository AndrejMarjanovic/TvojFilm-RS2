using Microsoft.AspNetCore.Mvc;
using TvojFilm.Model;
using TvojFilm.Model.Requests;
using TvojFilm.Services;

namespace TvojFilm.Controllers
{
    public class GradoviController : BaseCRUDController<Model.Gradovi, GradoviSearchRequest, GradoviInsertRequest, GradoviInsertRequest>
    {
        public GradoviController(ICRUDService<Model.Gradovi, GradoviSearchRequest, GradoviInsertRequest, GradoviInsertRequest> service) : base(service)
        {

        }
    }
}