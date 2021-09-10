using HeroesApi.DTOs;
using HeroesApi.Models;

namespace HeroesApi
{
    public static class Extensions
    {
        public static HeroDto AsDto(this Hero hero)
        {
            return new HeroDto()
            {
                Id = hero.Id,
                Name = hero.Name
            };
        }
    }
}