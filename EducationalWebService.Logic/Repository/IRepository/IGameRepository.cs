using EducationalWebService.Logic.DTO.Game;
using EducationalWebService.Logic.DTO.Jeopardy;

namespace EducationalWebService.Logic.Repository.IRepository;

public interface IGameRepository
{
    public Task<IEnumerable<GameDTO>> GetAllByUserIDAsync(Guid userID);

    public Task<GameDTO?> GetByIDAsync(Guid gameID);

    public Task<GameDTO> CreateAsync(Guid userID, GameRequest request);

    public Task<bool> UpdateAsync(Guid gameID, GameRequest request);

    public Task<bool> ClearAsync(Guid gameID);

    public Task<bool> DeleteAsync(Guid gameID);
}
