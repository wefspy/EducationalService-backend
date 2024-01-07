using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EducationalWebService.Data.Models;

[Table("Jeopardy_Session")]
public class JeopardySession
{
    [Column("id_session")]
    [Key]
    [NotNull]
    public Guid SessionID { get; set; }

    [Column("id_jeopardy")]
    [ForeignKey("Jeopardy")]
    [NotNull]
    public Guid JeopardyID { get; set; }

    [Column("time")]
    [NotNull]
    public DateTime Time { get; set; }

    public Jeopardy Jeopardy { get; set; }
}
