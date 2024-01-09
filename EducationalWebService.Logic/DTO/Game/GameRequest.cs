using System.ComponentModel.DataAnnotations;

namespace EducationalWebService.Logic.DTO.Game;

public class GameRequest
{
    [Required]
    public string Name { get; set; } = null!;
}
