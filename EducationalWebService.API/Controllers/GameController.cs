using EducationalWebService.Logic.DTO.Game;
using EducationalWebService.Logic.DTO.Jeopardy;
using EducationalWebService.Logic.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationalWebService.API.Controllers;

[Authorize]
[Route("api/{userID:Guid}/jeopardy")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameRepository _gameRepository;

    public GameController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameDTO>>> GetAllByUserID([FromRoute]Guid userID)
    {
        var result = await _gameRepository.GetAllByUserIDAsync(userID);

        //if (result == null)
        //    return NotFound();

        return Ok(result);
    }

    [HttpGet("{gameID:Guid}")]
    public async Task<ActionResult<GameDTO>> GetByID(Guid gameID)
    {
        var result = await _gameRepository.GetByIDAsync(gameID);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromRoute]Guid userID, string gameName)
    {
        await _gameRepository.CreateAsync(userID, gameName);

        return Ok();
    }

    [HttpPut("{gameID:Guid}")]
    public async Task<ActionResult> Update([FromRoute] Guid gameID, string gameName)
    {
        var isOk = await _gameRepository.UpdateAsync(gameID, gameName);

        if (isOk)
            return Ok();

        return NotFound();
    }

    [HttpDelete("{gameID:Guid}")]
    public async Task<ActionResult> Delete(Guid gameID)
    {
        var isOk = await _gameRepository.DeleteAsync(gameID);

        if (isOk)
            return Ok();

        return NotFound();
    }
}
