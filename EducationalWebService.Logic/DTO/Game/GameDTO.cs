using System.ComponentModel.DataAnnotations;

namespace EducationalWebService.Logic.DTO.Jeopardy;

public class GameDTO
{
    [Required]
    public Guid GameID { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}
