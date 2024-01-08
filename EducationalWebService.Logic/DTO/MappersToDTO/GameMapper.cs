using EducationalWebService.Data.Models;
using EducationalWebService.Logic.DTO.Jeopardy;

namespace EducationalWebService.Logic.DTO.MappersToDTO;

public static class GameMapper
{
    public static GameDTO ToDTO(JeopardyGame pack)
    {
        return new GameDTO
        {
            GameID = pack.GameID!,
            Name = pack.Name!,
        };
    }
}
