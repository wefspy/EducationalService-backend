using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EducationalWebService.Data.Models;

public class JeopardyTopic
{
    [Column("id_topic")]
    [Key]
    [NotNull]
    public Guid TopicID { get; set; }

    [Column("id_game")]
    [ForeignKey("JeopardyGame")]
    [NotNull]
    public Guid GameID { get; set; }

    [Column("title")]
    [NotNull]
    public string Title { get; set; }

    [Column("round")]
    [NotNull]
    public int Round { get; set; }

    public JeopardyGame JeopardyGame { get; set; }
}
