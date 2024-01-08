using System.ComponentModel.DataAnnotations;

namespace EducationalWebService.Logic.DTO.Question;

public class QuestionRequest
{
    [Required]
    public string Text { get; set; }

    public string Image { get; set; }

    public string Music { get; set; }

    [Required]
    public int Reward { get; set; }

    [Required]
    public string Answer { get; set; } = null!;
}
