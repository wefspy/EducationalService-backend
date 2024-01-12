using EducationalWebService.Logic.DTO.Game;
using EducationalWebService.Logic.DTO.Question;
using EducationalWebService.Logic.DTO.Topic;

namespace EducationalWebService.Logic.DTO.GamePack;

public class GamePackDTO
{
    public required GameDTO Game { get; set; }

    public required IEnumerable<TopicPackDTO> TopicPacks { get; set; }
}

public class TopicPackDTO
{
    public required TopicDTO Topic { get; set; }

    public required IEnumerable<QuestionDTO> QuestionPack { get; set; }
} 
