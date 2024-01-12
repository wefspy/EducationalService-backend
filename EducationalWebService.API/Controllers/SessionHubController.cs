using EducationalWebService.API.Hubs;
using EducationalWebService.Logic.Repository;
using EducationalWebService.Logic.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EducationalWebService.API.Controllers;

[Route("api/session")]
[ApiController]
public class SessionHubController : ControllerBase
{
    private readonly ISessionHubRepository _sessionHubRepository;
    private readonly IHubContext<SessionHub> _sessionHub;

    public SessionHubController(IHubContext<SessionHub> sessionHub, ISessionHubRepository sessionHubRepository)
    {
        _sessionHub = sessionHub;
        _sessionHubRepository = sessionHubRepository;
    }

    [HttpPost]
    public ActionResult<string> Create(Guid gameID, string userName)
    {
        var sessionCode = _sessionHubRepository.Create(gameID, userName);

        return Ok(sessionCode);
    }
}
