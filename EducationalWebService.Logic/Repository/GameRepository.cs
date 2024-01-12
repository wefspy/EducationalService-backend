using EducationalWebService.Data.Context;
using EducationalWebService.Logic.DTO.Game;
using EducationalWebService.Logic.DTO.Mappers;
using EducationalWebService.Logic.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EducationalWebService.Logic.Repository;

public class GameRepository : IGameRepository
{
    private readonly EducationalWebServiceContext _db;
    public GameRepository(EducationalWebServiceContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GameDTO>> GetAllByUserIDAsync(Guid userID)
    {
        var result = await _db.JeopardyGame
            .Where(game => game.UserID == userID)
            .Select(game => GameMapper.ModelObjectToDTO(game))
            .ToListAsync();

        //if (result.Count == 0) return null;

        return result;
    }

    public async Task<GameDTO?> GetByIDAsync(Guid gameID)
    {
        var result = await _db.JeopardyGame.FindAsync(gameID);

        if (result == null) return null;

        return GameMapper.ModelObjectToDTO(result);
    }

    public async Task<GameDTO> CreateAsync(Guid userID, GameRequest request)
    {
        var modelObject = GameMapper.RequestToModelObject(userID, request);

        await _db.JeopardyGame.AddAsync(modelObject);

        await _db.SaveChangesAsync();

        return GameMapper.ModelObjectToDTO(modelObject);
    }

    public async Task<bool> UpdateAsync(Guid gameID, GameRequest request)
    {
        var game = await _db.JeopardyGame.FindAsync(gameID);

        if (game == null) return false;

        game.Name = request.Name;

        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ClearAsync(Guid gameID)
    {
        var topicsToDelte = _db.JeopardyTopic
            .Where(topic => topic.GameID == gameID);

        _db.JeopardyTopic.RemoveRange(topicsToDelte);

        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(Guid gameID)
    {
        var game = await _db.JeopardyGame.FindAsync(gameID);

        if (game == null) return false;

        _db.JeopardyGame.Remove(game);

        await _db.SaveChangesAsync();

        return true;
    }
}
