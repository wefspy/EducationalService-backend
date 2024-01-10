using EducationalWebService.Data.Models;
using EducationalWebService.Logic.DTO.Game;
using EducationalWebService.Logic.DTO.Question;

namespace EducationalWebService.Logic.DTO.Mappers;

public static class QuestionMapper
{
    public static QuestionDTO ModelObjectToDTO(JeopardyQuestion question)
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

    public static QuestionDTO RequestToDTO(Guid questionID, QuestionRequest request)
    {
        return new QuestionDTO
        {
            QuestionID = questionID,
            Text = request.Text,
            //imagePath = request.Image, // TODO
            //musicPath = request.Music,
            Reward = request.Reward,
            Answer = request.Answer,
        };
    }

    public static JeopardyQuestion RequestToModelObject(Guid topicID, QuestionRequest request)
    {
        return new JeopardyQuestion
        {
            QuestionID = Guid.NewGuid(),
            TopicID = topicID,
            Text = request.Text,
            //imagePath = request.Image, // TODO
            //musicPath = request.Music,
            Reward = request.Reward,
            Answer = request.Answer,
        };
    }
}
