using EducationalWebService.Logic.DTO.Game;
using EducationalWebService.Logic.DTO.Question;
using EducationalWebService.Logic.DTO.Topic;

namespace EducationalWebService.Logic.DTO.GamePack;

public class GamePackRequest
{
    public required GameRequest Game { get; set; }

    public required IEnumerable<TopicPackRequest> TopicPacks { get; set; }
}

public class TopicPackRequest
{
    public required TopicRequest Topic { get; set; }

    public required IEnumerable<QuestionRequest> QuestionPack { get; set; }
}