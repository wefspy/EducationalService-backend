using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EducationalWebService.Data.Models;

public class JeopardyQuestion
{
    [Key]
    [NotNull]
    public Guid QuestionID { get; set; }

    [ForeignKey("JeopardyTopic")]
    [NotNull]
    public Guid TopicID { get; set; }

    [NotNull]
    public string Text { get; set; }

    public string? ImagePath { get; set; }

    public string? MusicPath { get; set; }

    [NotNull]
    public int Reward { get; set; }

    [NotNull]
    public string Answer { get; set; }

    public JeopardyTopic JeopardyTopic { get; set; }
}
