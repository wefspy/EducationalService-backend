using EducationalWebService.Data.Models;

namespace EducationalWebService.Logic.Repository.IRepository;

public interface ISessionHubRepository
{
    public Dictionary<string, HubSession> GetAll();

    public HubSession? Get(string sessionCode);

    public string Create(Guid gameID, string userName);

    public HubSession? AddPlayer(string sessionCode, HubPlayer player);

    public HubSession? UpdatePlayerScore(string sessionCode, string playerName, int scoreDifference);

    public bool DeletePlayer(string sessionCode, string playerName);

    public bool Delete(string sessionCode);
}