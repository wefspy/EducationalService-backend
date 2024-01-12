using System.ComponentModel.DataAnnotations;

namespace EducationalWebService.Logic.DTO.Game;

public class GameDTO : GameRequest
{
    [Required]
    public Guid GameID { get; set; }
}
