namespace SuperHeroApi.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
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
        public List<SuperHero> AddHero(SuperHero hero)
        {
            throw new NotImplementedException();
        }

        public List<SuperHero> DeleteHero(int id)
        {
            throw new NotImplementedException();
        }

        public List<SuperHero> GetAllHeroes()
        {
            throw new NotImplementedException();
        }

        public SuperHero GetHero(int id)
        {
            throw new NotImplementedException();
        }

        public List<SuperHero> UpdateHero(int id, SuperHero request)
        {
            throw new NotImplementedException();
        }
    }
}
