using System.ComponentModel.DataAnnotations;

namespace HeroesApi.DTOs
{
    public class AddHeroDto
    {
        [Required] public string Name { get; init; }
    }
}