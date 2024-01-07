using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EducationalWebService.Data.Models;

[Table("Users")]
public class User : IdentityUser<Guid>
{
    [Column("id_user")]
    [Key]
    [NotNull]
    public Guid Id { get; set; }

    [Column("user_name")]
    [NotNull]
    public string Name { get; set; }

    [Column("email")]
    [NotNull]
    public string Email { get; set; }
}
