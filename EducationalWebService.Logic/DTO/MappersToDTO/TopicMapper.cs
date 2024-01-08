using EducationalWebService.Data.Models;
using EducationalWebService.Logic.DTO.Topic;

namespace EducationalWebService.Logic.DTO.MappersToDTO;

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
}
