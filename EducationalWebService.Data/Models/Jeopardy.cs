using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EducationalWebService.Data.Models;

[Table("Jeopardy")]
public class Jeopardy
{
    [Column("id_jeopardy")]
    [Key]
    [NotNull]
    public Guid Id { get; set; }

    [Column("id_user")]
    [ForeignKey("User")]
    [NotNull]
    public Guid UserID { get; set; }

    [Column("name")]
    [NotNull]
    public string Name { get; set; }

    public User User { get; set; }
}
