using EducationalWebService.Logic.DTO.Jeopardy;

namespace EducationalWebService.Logic.Repository.IRepository;

public interface IGameRepository
{
    public Task<IEnumerable<GameDTO>?> GetAllByUserIDAsync(Guid userID);

    public Task<GameDTO?> GetByIDAsync(Guid gameID);

    public Task<bool> CreateAsync(Guid userID, string gameName);

    public Task<bool> UpdateAsync(Guid gameID, string gameName);

    public Task<bool> DeleteAsync(Guid gameID);
}
