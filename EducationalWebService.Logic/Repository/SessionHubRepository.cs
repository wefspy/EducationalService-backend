using EducationalWebService.Data.Context;
using EducationalWebService.Data.Models;
using EducationalWebService.Logic.DTO.Game;
using EducationalWebService.Logic.Generator.IGenerator;
using EducationalWebService.Logic.Repository.IRepository;
using System.Numerics;

namespace EducationalWebService.Logic.Repository;

public class SessionHubRepository : ISessionHubRepository
{
    private readonly ISessionCodeGenerator _sessionCodeGenerator;

    public SessionHubRepository(ISessionCodeGenerator sessionCodeGenerator)
    {
        _sessionCodeGenerator = sessionCodeGenerator;
    }

    public Dictionary<string, HubSession> GetAll()
    {
        return SignalRContext.Hubs;
    }

    public HubSession? Get(string sessionCode)
    {
        if (SignalRContext.Hubs.TryGetValue(sessionCode, out HubSession hubSession))
            return hubSession;

        return null;
    }

    public string Create(GameDTO gameDTO, string userName)
    {
        var sessionCode = _sessionCodeGenerator.GenerateSessionCode(8); // constant value password length        

        var hubSession = new HubSession()
        {
            GameID = gameDTO.GameID,
            GameName = gameDTO.Name,
            UserName = userName,
            Players = new List<HubPlayer>(),
        };

        SignalRContext.Hubs.Add(sessionCode, hubSession);

        return sessionCode;
    }

    public HubSession? AddPlayer(string sessionCode, HubPlayer player)
    {
        if (SignalRContext.Hubs.TryGetValue(sessionCode, out HubSession hubSession))
        {
            hubSession.Players.Add(player);
            return hubSession;
        }

        return null;
    }

    public HubSession? UpdatePlayerScore(string sessionCode, string playerName, int scoreDifference)
    {
        if (SignalRContext.Hubs.TryGetValue(sessionCode, out HubSession hubSession))
        {
            var item = hubSession.Players.Find(x => x.Name == playerName);
            if (item != null)
            {
                item.Score += scoreDifference;
                return hubSession;
            }     
        }

        return null;
    }

    public bool DeletePlayer(string sessionCode, string playerName)
    {
        if (SignalRContext.Hubs.TryGetValue(sessionCode, out HubSession hubSession))
        {
            var player = hubSession.Players.Find(player => player.Name == playerName);
            if (player != null)
            {
                hubSession.Players.Remove(player);
                return true;
            }
        }

        return false;
    }

    public bool Delete(string sessionCode)
    {
        return SignalRContext.Hubs.Remove(sessionCode);
    }
}
