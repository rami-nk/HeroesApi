using System.Collections.Generic;
using System.Linq;
using HeroesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroesApi.Repositories
{
    public class MySqlDbContext : DbContext, IHeroRepository
    {
        private DbSet<Hero> TourHeroes { get; set; }

        public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
            : base(options)
        {
        }

        public IEnumerable<Hero> GetHeroes()
        {
            return TourHeroes.ToList();
        }

        public Hero GetHero(long id)
        {
            return TourHeroes.Find(id);
        }

        public void AddHero(Hero hero)
        {
            TourHeroes.AddRange(hero);
            SaveChanges();
        }

        public void UpdateHero(Hero hero)
        {
            var currentHero = TourHeroes.Find(hero.Id);
            Entry(currentHero).CurrentValues.SetValues(hero);
            SaveChanges();
        }

        public void DeleteHero(long id)
        {
            TourHeroes.Remove(GetHero(id));
            SaveChanges();
        }
    }
}