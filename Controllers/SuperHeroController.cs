using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;
using System.Xml.Linq;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "Spider-Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
            },
            new SuperHero
            {
                Id = 2,
                Name = "Iron Man",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "Malibu"
            },
        };

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
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return NotFound("This Hero doesn't exist!");

            superHeroes.Remove(hero);

            return Ok(superHeroes);
        }

    }
}
