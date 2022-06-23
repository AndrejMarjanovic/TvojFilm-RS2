using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TvojFilm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace TvojFilm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController<T, TSearch> : ControllerBase
    {
        protected readonly IService<T, TSearch> _service;

        public BaseController(IService<T, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<T>> Get([FromQuery] TSearch request)
        {
            return _service.Get(request);
        }

        [HttpGet("{id}")]
        public ActionResult<T> GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
