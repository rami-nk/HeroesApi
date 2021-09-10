using System.Collections.Generic;
using HeroesApi.Models;

namespace HeroesApi.Repositories
{
    public interface IHeroRepository
    {
        IEnumerable<Hero> GetHeroes();
        Hero GetHero(long id);
        void AddHero(Hero hero);

        void UpdateHero(Hero hero);

        void DeleteHero(long id);
    }
}