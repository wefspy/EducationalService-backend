using System.ComponentModel.DataAnnotations;

namespace EducationalWebService.Logic.DTO.User;

public class UserRegistrationRequest
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;
}
