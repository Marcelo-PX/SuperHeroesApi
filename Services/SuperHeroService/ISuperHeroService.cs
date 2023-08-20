namespace SuperHeroApi.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        SuperHero GetHero(int id);
        List<SuperHero>? AddHero(SuperHero hero);
        List<SuperHero>? UpdateHero(int id, SuperHero request);
        List<SuperHero>? DeleteHero(int id);
    }
}
