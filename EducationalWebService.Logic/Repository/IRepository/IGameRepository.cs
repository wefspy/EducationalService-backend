using EducationalWebService.Logic.DTO.Game;
using EducationalWebService.Logic.DTO.Jeopardy;

namespace EducationalWebService.Logic.Repository.IRepository;

public interface IGameRepository
{
    public Task<IEnumerable<GameDTO>?> GetAllByIDAsync(Guid userID);

    public Task<GameDTO?> GetByIDAsync(Guid gameID);

    public Task<bool> CreateAsync(GameCreateRequest request);

    public Task<bool> RenameAsync(GameRenameRequest request);

    public Task<bool> DeleteAsync(Guid gameID);
}
