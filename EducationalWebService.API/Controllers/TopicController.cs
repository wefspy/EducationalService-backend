using EducationalWebService.Logic.DTO.Jeopardy;
using EducationalWebService.Logic.DTO.Topic;
using EducationalWebService.Logic.Repository;
using EducationalWebService.Logic.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationalWebService.API.Controllers;

[Authorize]
[Route("api/{userID:Guid}/jeopardy/{gameID:Guid}/topic")]
[ApiController]
public class TopicController : ControllerBase
{
    private readonly ITopicRepository _topicRepository;

    public TopicController(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TopicDTO>>> GetAllByGameID([FromRoute]Guid gameID)
    {
        var result = await _topicRepository.GetAllByGameIDAsync(gameID);

        //if (result == null) 
        //    return NotFound();

        return Ok(result);
    }

    [HttpGet("{topicID:Guid}")]
    public async Task<ActionResult<IEnumerable<TopicDTO>>> GetByID(Guid topicID)
    {
        var result = await _topicRepository.GetByIDAsync(topicID);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<TopicDTO>> Create(TopicRequest request, [FromRoute]Guid gameID)
    {
        var result = await _topicRepository.CreateAsync(gameID, request);

        return Ok(result);
    }

    [HttpPut("{topicID:Guid}")]
    public async Task<ActionResult> Update(TopicRequest request, [FromRoute]Guid topicID)
    {
        var isOk = await _topicRepository.UpdateAsync(topicID, request);

        if (isOk)
            return Ok();

        return NotFound();
    }

    [HttpDelete("{topicID:Guid}")]
    public async Task<ActionResult> Delete(Guid topicID)
    {
        var isOk = await _topicRepository.DeleteAsync(topicID);

        if (isOk)
            return Ok();

        return NotFound();
    }
}
