using System.Collections.Generic;
using System.Linq;
using HeroesApi.DTOs;
using HeroesApi.Models;
using HeroesApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HeroesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroRepository _repository;

        public HeroesController(IHeroRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<HeroDto> GetHeroes()
        {
            return _repository.GetHeroes().Select(hero => hero.AsDto());
        }

        [HttpGet("{id}")]
        public ActionResult<HeroDto> GetHero(long id)
        {
            var hero = _repository.GetHero(id);

            if (hero == null) return NotFound();

            return hero.AsDto();
        }

        [HttpPost]
        public ActionResult<HeroDto> AddHero(AddHeroDto addHeroDto)
        {
            var hero = new Hero()
            {
                Id = IdGenerator.NewId(_repository.GetHeroes()),
                Name = addHeroDto.Name
            };

            _repository.AddHero(hero);
            return CreatedAtAction(nameof(GetHero), new {Id = hero.Id}, hero);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateHero(long id, UpdateHeroDto updatedHeroDto)
        {
            var existingHero = _repository.GetHero(id);

            if (existingHero == null) return NotFound();

            var hero = new Hero()
            {
                Id = existingHero.Id,
                Name = updatedHeroDto.Name
            };

            _repository.UpdateHero(hero);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteHero(long id)
        {
            var hero = _repository.GetHero(id);

            if (hero == null) return NotFound();

            _repository.DeleteHero(id);
            return Ok();
        }
    }
}