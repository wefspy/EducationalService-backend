using EducationalWebService.Data.Models;
using EducationalWebService.Logic.Repository;
using EducationalWebService.Logic.Repository.IRepository;
using Microsoft.AspNetCore.SignalR;


namespace EducationalWebService.API.Hubs;

public class SessionHub : Hub
{
    private readonly ISessionHubRepository _sessionHubRepository;

    public SessionHub(ISessionHubRepository sessionHubRepository)
    {
        _sessionHubRepository = sessionHubRepository;
    }

    public async Task JoinTeam(string sessionCode, string playerName, string role)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, sessionCode);

        if (role == "student")
            _sessionHubRepository.AddPlayer(sessionCode, new HubPlayer() { Name = playerName, Score = 0});

        await Clients.Group(sessionCode).SendAsync("Notify", _sessionHubRepository.Get(sessionCode));
    }

    public async Task StartGame(string sessionCode)
    {
        await Clients.Group(sessionCode).SendAsync("GamePush");
    }

    public async Task GetHubInfo(string sessionCode)
    {
        await Clients.Group(sessionCode).SendAsync("Notify", _sessionHubRepository.Get(sessionCode));
    }

    public async Task FinishGame(string sessionCode)
    {
        await Clients.Group(sessionCode).SendAsync("GamePull");

        _sessionHubRepository.Delete(sessionCode);
    }

    public async Task DisconnectPlayer(string sessionCode, string playerName)
    {
        _sessionHubRepository.DeletePlayer(sessionCode, playerName);

        await Clients.Group(sessionCode).SendAsync("Notify", _sessionHubRepository.Get(sessionCode));
    }

    public async Task HandleQuestion(string sessionCode, int topicID, int questionID)
    {
        await Clients.Group(sessionCode).SendAsync("OpenQuestion", topicID, questionID);
    }

    public async Task GiveAnswer(string sessionCode, string playerName, string answer)
    {
        await Clients.Group(sessionCode).SendAsync("GetAnswer", playerName, answer);
    }

    public async Task NoAnswers(string sessionCode)
    {
        await Clients.Group(sessionCode).SendAsync("QuestionResolve");
    }

    public async Task HandleAnswer(string sessionCode, string playerName, int scoreDifference)
    {
        _sessionHubRepository.UpdatePlayerScore(sessionCode, playerName, scoreDifference);

        await Clients.Group(sessionCode).SendAsync("Notify", _sessionHubRepository.Get(sessionCode));

        await Clients.Group(sessionCode).SendAsync("QuestionResolve");
    }

    public async Task BlockButton(string sessionCode)
    {
        await Clients.Group(sessionCode).SendAsync("BlockButton");
    }

    public async Task ChangeRound(string sessionCode)
    {
        await Clients.Group(sessionCode).SendAsync("SwitchRound");
    }
}
