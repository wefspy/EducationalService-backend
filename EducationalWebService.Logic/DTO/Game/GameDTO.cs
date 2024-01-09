using EducationalWebService.Logic.DTO.Game;
using System.ComponentModel.DataAnnotations;

namespace EducationalWebService.Logic.DTO.Jeopardy;

public class GameDTO : GameRequest
{
    [Required]
    public Guid GameID { get; set; }
}
