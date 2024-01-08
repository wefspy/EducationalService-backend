using EducationalWebService.Data.Context;
using EducationalWebService.Data.Models;
using EducationalWebService.Logic.DTO.Game;
using EducationalWebService.Logic.DTO.Jeopardy;
using EducationalWebService.Logic.DTO.MappersToDTO;
using EducationalWebService.Logic.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace EducationalWebService.Logic.Repository;

public class GameRepository : IGameRepository
{
    private readonly EducationalWebServiceContext _db;
    public GameRepository(EducationalWebServiceContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GameDTO>?> GetAllByIDAsync(Guid userID)
    {
        var result = await _db.JeopardyGame
            .Where(game => game.UserID == userID)
            .Select(game => GameMapper.ToDTO(game))
            .ToListAsync();

        if (result.Count == 0) return null;

        return result;
    }

    public async Task<GameDTO?> GetByIDAsync(Guid gameID)
    {
        var result = await _db.JeopardyGame.FindAsync(gameID);

        if (result == null) return null;

        return GameMapper.ToDTO(result);
    }

    public async Task<bool> CreateAsync(GameCreateRequest request)
    {
        await _db.JeopardyGame.AddAsync(new JeopardyGame
        {
            UserID = request.UserID,
            Name = request.GameName,
        });

        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RenameAsync(GameRenameRequest request)
    {
        var game = await _db.JeopardyGame.FindAsync(request.GameID);

        if (game == null) return false;

        game.Name = request.GameName;

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
