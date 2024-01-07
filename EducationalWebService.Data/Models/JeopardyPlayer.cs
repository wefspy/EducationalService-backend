using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EducationalWebService.Data.Models;

[Table("Jeopardy_Player")]
public class JeopardyPlayer
{
    [Column("id_player")]
    [Key]
    [NotNull]
    public Guid PlayerID { get; set; }

    [Column("id_session")]
    [ForeignKey("JeopardySession")]
    [NotNull]
    public Guid SessionID { get; set; }

    [Column("name")]
    [NotNull]
    public string Name { get; set; }

    [Column("score_round_1")]
    [NotNull]
    public int ScoreRound1 { get; set; }

    [Column("score_round_2")]
    [NotNull]
    public string ScoreRound2 { get; set; }

    [Column("score_round_3")]
    [NotNull]
    public Guid ScoreRound3 { get; set; }

    [Column("answer_for_final_question")]
    [NotNull]
    public string answerFinalQuestion { get; set; }

    [Column("total_score")]
    [NotNull]
    public string totalScore { get; set; }

    public JeopardySession JeopardySession { get; set; }
}
