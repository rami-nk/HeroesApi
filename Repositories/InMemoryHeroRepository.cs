using System.Collections.Generic;
using HeroesApi.Models;

namespace HeroesApi.Repositories
{
    public class InMemoryHeroRepository : IHeroRepository
    {
        private readonly List<Hero> _heroes = new()
        {
            new Hero {Id = IdGenerator.NewId(), Name = "Dr Nice"},
            new Hero {Id = IdGenerator.NewId(), Name = "Narco"},
            new Hero {Id = IdGenerator.NewId(), Name = "Bombasto"},
            new Hero {Id = IdGenerator.NewId(), Name = "Celeritas"},
            new Hero {Id = IdGenerator.NewId(), Name = "Magneta"},
            new Hero {Id = IdGenerator.NewId(), Name = "RubberMan"},
            new Hero {Id = IdGenerator.NewId(), Name = "Dynama"},
            new Hero {Id = IdGenerator.NewId(), Name = "Dr IQ"},
            new Hero {Id = IdGenerator.NewId(), Name = "Magma"},
            new Hero {Id = IdGenerator.NewId(), Name = "Tornado"}
        };

        public IEnumerable<Hero> GetHeroes()
        {
            return _heroes;
        }

        public Hero GetHero(long id)
        {
            return _heroes.Find(hero => hero.Id == id);
        }

        public void AddHero(Hero hero)
        {
            _heroes.Add(hero);
        }

        public void UpdateHero(Hero hero)
        {
            var idx = _heroes.FindIndex(listItem => listItem.Id == hero.Id);
            _heroes[idx] = hero;
        }

        public void DeleteHero(long id)
        {
            var idx = _heroes.FindIndex(listItem => listItem.Id == id);
            _heroes.RemoveAt(idx);
        }
    }
}