using EducationalWebService.Logic.DTO.GamePack;
using EducationalWebService.Logic.Repository;
using EducationalWebService.Logic.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationalWebService.API.Controllers;

[Authorize]
[Route("api/{userID:Guid}/gamepack")]
[ApiController]
public class GamePackController : ControllerBase
{
    private readonly IGamePackRepository _gamePackRepository;

    public GamePackController (IGamePackRepository gamePackRepository)
    {
        _gamePackRepository = gamePackRepository;
    }

    [HttpGet("{gameID:Guid}")]
    public async Task<ActionResult<GamePackDTO>> GetByGameID(Guid gameID)
    {
        var result = await _gamePackRepository.GetByGameIDAsync(gameID);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GamePackDTO>> Create([FromRoute] Guid userID, GamePackRequest request)
    {
        var result = await _gamePackRepository.CreateAsync(userID, request);

        return Ok(result);
    }

    [HttpPut("{gameID:Guid}")]
    public async Task<ActionResult<GamePackDTO>> Update(Guid gameID, GamePackRequest request)
    {
        var result = await _gamePackRepository.UpdateAsync(gameID, request);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{gameID:Guid}")]
    public async Task<ActionResult> Delete(Guid gameID)
    {
        var isOk = await _gamePackRepository.DeleteAsync(gameID);

        if (isOk)
            return Ok();

        return NotFound();
    }
}
