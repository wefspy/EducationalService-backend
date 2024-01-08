using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EducationalWebService.Data.Models;

public class JeopardyTopic
{
    [Column("id_topic")]
    [Key]
    [NotNull]
    public Guid Id { get; set; }

    [Column("id_jeopardy")]
    [ForeignKey("JeopardyGamePack")]
    [NotNull]
    public Guid JeopardyID { get; set; }

    [Column("title")]
    [NotNull]
    public string Title { get; set; }

    [Column("round")]
    [NotNull]
    public int Round { get; set; }

    public JeopardyGame JeopardyGamePack { get; set; }
}
