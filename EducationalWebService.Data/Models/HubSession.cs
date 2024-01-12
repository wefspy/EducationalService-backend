using System.ComponentModel.DataAnnotations;

namespace EducationalWebService.Data.Models;

public class HubSession
{
    [Required]
    public Guid GameID { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public List<HubPlayer> Players { get; set; }
}
