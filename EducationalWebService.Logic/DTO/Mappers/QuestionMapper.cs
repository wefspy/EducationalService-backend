using EducationalWebService.Data.Models;
using EducationalWebService.Logic.DTO.Question;

namespace EducationalWebService.Logic.DTO.Mappers;

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

    public static JeopardyQuestion ToModelObject(Guid topicID, QuestionRequest request)
    {
        return new JeopardyQuestion
        {
            TopicID = topicID,
            Text = request.Text,
            //imagePath = request.Image, // TODO
            //musicPath = request.Music,
            Reward = request.Reward,
            Answer = request.Answer,
        };
    }
}
