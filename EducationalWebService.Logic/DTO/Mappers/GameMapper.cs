using EducationalWebService.Data.Models;
using EducationalWebService.Logic.DTO.Game;
using EducationalWebService.Logic.DTO.Game;

namespace EducationalWebService.Logic.DTO.Mappers;

public static class GameMapper
{
    public static GameDTO ModelObjectToDTO(JeopardyGame game)
    {
        return new GameDTO
        {
            GameID = game.GameID,
            Name = game.Name,
        };
    }

    public static GameDTO RequestToDTO(Guid gameID, GameRequest request)
    {
        return new GameDTO
        {
            GameID = gameID,
            Name = request.Name,
        };
    }

    public static JeopardyGame RequestToModelObject(Guid userID, GameRequest request)
    {
        return new JeopardyGame()
        {
            GameID = Guid.NewGuid(),
            UserID = userID,
            Name = request.Name,
        };
    }
}
