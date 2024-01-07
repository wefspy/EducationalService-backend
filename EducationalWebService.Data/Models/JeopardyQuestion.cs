using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EducationalWebService.Data.Models;

[Table("Jeopardy_Question")]
public class JeopardyQuestion
{
    [Column("id_question")]
    [Key]
    [NotNull]
    public Guid Id { get; set; }

    [Column("id_topic")]
    [ForeignKey("JeopardyTopic")]
    [NotNull]
    public Guid TopicID { get; set; }

    [Column("text")]
    [NotNull]
    public string Text { get; set; }

    [Column("image")]
    public string? imagePath { get; set; }

    [Column("music")]
    public string? musicPath { get; set; }

    [Column("reward")]
    [NotNull]
    public int Reward { get; set; }

    [Column("answer")]
    [NotNull]
    public string Answer { get; set; }

    public JeopardyTopic JeopardyTopic { get; set; }
}
