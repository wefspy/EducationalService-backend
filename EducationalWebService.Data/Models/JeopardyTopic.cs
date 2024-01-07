using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EducationalWebService.Data.Models;

[Table("Jeopardy_Topic")]
public class JeopardyTopic
{
    [Column("id_topic")]
    [Key]
    [NotNull]
    public Guid Id { get; set; }

    [Column("id_jeopardy")]
    [ForeignKey("Jeopardy")]
    [NotNull]
    public Guid JeopardyID { get; set; }

    [Column("title")]
    [NotNull]
    public string Title { get; set; }

    [Column("round")]
    [NotNull]
    public int Round { get; set; }

    public Jeopardy Jeopardy { get; set; }
}
