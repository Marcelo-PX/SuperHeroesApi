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

        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            return Ok(superHeroes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSingleHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return NotFound("This Hero doesn't exist!");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> Addhero(SuperHero hero)
        {
            superHeroes.Add(hero);

            return Ok(superHeroes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHero(int id, SuperHero request)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null) 
                return NotFound("This Hero doesn't exist!");

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(superHeroes);
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
