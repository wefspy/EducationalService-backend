using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EducationalWebService.Data.Models;

public class JeopardySession
{
    [Key]
    [NotNull]
    public Guid SessionID { get; set; }

    [ForeignKey("Jeopardy")]
    [NotNull]
    public Guid JeopardyID { get; set; }

    [NotNull]
    public DateTime Time { get; set; }

    public JeopardyGame Jeopardy { get; set; }
}
