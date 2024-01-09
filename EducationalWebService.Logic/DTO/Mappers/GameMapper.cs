using EducationalWebService.Data.Models;
using EducationalWebService.Logic.DTO.Game;
using EducationalWebService.Logic.DTO.Jeopardy;

namespace EducationalWebService.Logic.DTO.Mappers;

public static class GameMapper
{
    public static GameDTO ToDTO(JeopardyGame game)
    {
        return new GameDTO
        {
            GameID = game.GameID!,
            Name = game.Name!,
        };
    }

    public static JeopardyGame ToModelObject(Guid userID, GameRequest request)
    {
        return new JeopardyGame()
        {
            UserID = userID,
            Name = request.Name,
        };
    }
}
