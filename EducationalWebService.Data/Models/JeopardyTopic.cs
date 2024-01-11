using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EducationalWebService.Data.Models;

public class JeopardyTopic
{
    [Key]
    [NotNull]
    public Guid TopicID { get; set; }

    [ForeignKey("JeopardyGame")]
    [NotNull]
    public Guid GameID { get; set; }

    [NotNull]
    public string Title { get; set; }

    [NotNull]
    public int Round { get; set; }

    public JeopardyGame JeopardyGame { get; set; }
}
