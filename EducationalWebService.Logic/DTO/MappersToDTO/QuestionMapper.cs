using EducationalWebService.Data.Models;
using EducationalWebService.Logic.DTO.Question;

namespace EducationalWebService.Logic.DTO.MappersToDTO;

public static class QuestionMapper
{
    public static QuestionDTO ToDTO(JeopardyQuestion question)
    {
        return new QuestionDTO
        {
            QuestionID = question.QuestionID!,
            Text = question.Text!,
            //Image = question.imagePath,   // TODO
            //Music = question.musicPath,
            Reward = question.Reward!,
            Answer = question.Answer!,
        }; 
    }
}
