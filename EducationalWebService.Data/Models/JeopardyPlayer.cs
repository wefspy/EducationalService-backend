using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EducationalWebService.Data.Models;

public class JeopardyPlayer
{
    [Key]
    [NotNull]
    public Guid PlayerID { get; set; }

    [ForeignKey("JeopardySession")]
    [NotNull]
    public Guid SessionID { get; set; }

    [NotNull]
    public string Name { get; set; }

    [NotNull]
    public int ScoreRound1 { get; set; }

    [NotNull]
    public int ScoreRound2 { get; set; }

    [NotNull]
    public int ScoreRound3 { get; set; }

    [NotNull]
    public string AnswerFinalQuestion { get; set; }

    [NotNull]
    public int TotalScore { get; set; }

    public JeopardySession JeopardySession { get; set; }
}
