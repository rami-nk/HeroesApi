using System.ComponentModel.DataAnnotations;

namespace HeroesApi.DTOs
{
    public class UpdateHeroDto
    {
        [Required] public string Name { get; init; }
    }
}