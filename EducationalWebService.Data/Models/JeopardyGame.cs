using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EducationalWebService.Data.Models;

public class JeopardyGame
{
    [Key]
    [NotNull]
    public Guid GameID { get; set; }

    [ForeignKey("User")]
    [NotNull]
    public Guid UserID { get; set; }

    [NotNull]
    public string Name { get; set; }

    public User User { get; set; }
}
