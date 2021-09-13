using System.Collections.Generic;
using System.Linq;
using HeroesApi.Models;

namespace HeroesApi
{
    public static class IdGenerator
    {
        private static long _current = 1;
        public static long NewId(IEnumerable<Hero> heroes)
        {
            var highestIdx = heroes.Select(item => item.Id).Prepend(0).Max();
            return highestIdx + 1;
        }
        
        public static long NewId()
        {
            long tmp = _current;
            _current++;
            return tmp;
        }
    }
}