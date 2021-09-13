using System;
using System.Collections.Generic;
using System.Linq;
using HeroesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HeroesApi.Repositories
{
    public class MySqlDbContext : DbContext, IHeroRepository
    {
        public DbSet<Hero> tourHeroes { get; set; }
        
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
            : base(options) 
        { }
        
        public IEnumerable<Hero> GetHeroes()
        {
            return tourHeroes.ToList();
        }

        public Hero GetHero(long id)
        {
            return tourHeroes.Find(id);
        }

        public void AddHero(Hero hero)
        {
            Console.Write("hero ID: " + hero.Id);
            tourHeroes.AddRange(hero);
        }

        public void UpdateHero(Hero hero)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteHero(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}