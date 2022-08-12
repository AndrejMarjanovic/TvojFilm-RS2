using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using TvojFilm.Model;
using TvojFilm.Model.Requests;
using TvojFilm.Services;

namespace TvojFilm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {

        private readonly IKorisniciService _service;
        public KorisniciController(IKorisniciService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Authorize]
        public List<Model.Korisnici> Get([FromQuery] KorisnikSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpPost]
        public Model.Korisnici Insert(KorisnikInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public Model.Korisnici Update(int id, [FromBody] KorisnikUpdateRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpGet("{id}")]
        [Authorize]
        public Model.Korisnici GetById(int id)
        {
            return _service.GetbyId(id);
        }
    }
}