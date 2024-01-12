using System.ComponentModel.DataAnnotations;

namespace EducationalWebService.Data.Models;

public class HubPlayer
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public int Score { get; set; }
}
