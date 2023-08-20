using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;
using SuperHeroApi.Services.SuperHeroService;
using System.Xml.Linq;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpPost]
        public async Task<IActionResult> AddHero(SuperHero hero)
        {
            var result = _superHeroService.AddHero(hero);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        { 
            return await _superHeroService.GetAllHeroes();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetHero(int id)
        {
            var result = _superHeroService.GetHero(id);
            if (result is null)
                return NotFound("Herói não encontrado!");

            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHero(int id, SuperHero request)
        {
            var result = _superHeroService.UpdateHero(id, request);
            if (result is null)
                return NotFound("Herói não encontrado!");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var result = _superHeroService.DeleteHero(id);
            if (result is null)
                return NotFound("Herói não encontrado!");

            return Ok(result);
        }
    }
}
