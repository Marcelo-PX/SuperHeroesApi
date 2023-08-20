using SuperHeroApi.Models;
using System.Collections.Generic;

namespace SuperHeroApi.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {   
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "spider-man",
                FirstName = "peter",
                LastName = "parker",
                Place = "new york city"
            },
            new SuperHero
            {
                Id = 2,
                Name = "iron man",
                FirstName = "tony",
                LastName = "stark",
                Place = "malibu"
            },
        };
        
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public List<SuperHero> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return superHeroes;
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public SuperHero? GetHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return null;

            return hero;
        }

        public List<SuperHero>? UpdateHero(int id, SuperHero request)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return null;

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return superHeroes;
        }

        public List<SuperHero>? DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return null;
            superHeroes.Remove(hero);
            return superHeroes;
        }
    }
}
