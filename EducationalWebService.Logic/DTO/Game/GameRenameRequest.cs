using System.ComponentModel.DataAnnotations;

namespace EducationalWebService.Logic.DTO.Game;

public class GameRenameRequest
{
    [Required]
    public Guid GameID { get; set; }

    [Required]
    public string GameName { get; set; } = null!;
}
