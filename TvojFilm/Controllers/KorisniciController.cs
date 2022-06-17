using Microsoft.AspNetCore.Mvc;
using TvojFilm.Model;
using TvojFilm.Services;

namespace TvojFilm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {

        private readonly IKorisniciService _service;
        public KorisnikController(IKorisniciService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Korisnici> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]
        public Model.Korisnici GetById(int id)
        {
            return _service.GetbyId(id);
        }


    }
}