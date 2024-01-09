using EducationalWebService.Data.Models;
using EducationalWebService.Logic.DTO.Topic;

namespace EducationalWebService.Logic.DTO.Mappers;

public static class TopicMapper
{
    public static TopicDTO ToDTO(JeopardyTopic topic)
    {
        return new TopicDTO
        {
            TopicID = topic.TopicID!,
            Title = topic.Title!,
            Round = topic.Round!,
        };
    }

    public static JeopardyTopic ToModelObject(Guid gameID, TopicRequest request)
    {
        return new JeopardyTopic
        {
            TopicID = Guid.NewGuid(),
            GameID = gameID,
            Title = request.Title,
            Round = request.Round,
        };
    }
}
