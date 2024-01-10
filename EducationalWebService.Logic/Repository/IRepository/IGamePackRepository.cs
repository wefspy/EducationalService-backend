using EducationalWebService.Logic.DTO.GamePack;

namespace EducationalWebService.Logic.Repository.IRepository;

public interface IGamePackRepository
{
    public Task<GamePackDTO?> GetByGameIDAsync(Guid gameID);

    public Task<GamePackDTO> CreateAsync(Guid userID, GamePackRequest request);

    public Task<GamePackDTO?> UpdateAsync(Guid gameID, GamePackRequest request);

    public Task<bool> DeleteAsync(Guid gameID);
}
