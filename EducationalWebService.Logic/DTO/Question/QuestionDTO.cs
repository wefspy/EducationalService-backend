using System.ComponentModel.DataAnnotations;

namespace EducationalWebService.Logic.DTO.Question;

public class QuestionDTO : QuestionRequest
{
    [Required]
    public Guid QuestionID { get; set; }
}
