using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TvojFilm.Model;
using TvojFilm.Model.Requests;
using TvojFilm.Services;

namespace TvojFilm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecommendedController : ControllerBase
    {
        private readonly IRecommendedService _repository;
        public RecommendedController(IRecommendedService repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult RecommendedProduct(int id)
        {
            try
            {
                return Ok(_repository.RecommendedProduct(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}