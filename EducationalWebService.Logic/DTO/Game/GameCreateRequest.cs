using System.ComponentModel.DataAnnotations;

namespace EducationalWebService.Logic.DTO.Game;

public class GameCreateRequest
{
    [Required]
    public Guid UserID { get; set; }

    [Required]
    public string GameName { get; set; } = null!;
}
