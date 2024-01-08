using EducationalWebService.Logic.DTO.Jeopardy;
using EducationalWebService.Logic.DTO.Topic;
using EducationalWebService.Logic.Repository;
using EducationalWebService.Logic.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EducationalWebService.API.Controllers;

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
    public async Task<ActionResult> Create(TopicCreateRequest request, [FromRoute]Guid gameID)
    {
        var result = await _topicRepository.CreateAsync(gameID, request);

        return Ok();
    }

    [HttpPut("{topicID:Guid}")]
    public async Task<ActionResult> Update(TopicUpdateRequest request, [FromRoute]Guid topicID)
    {
        var result = await _topicRepository.UpdateAsync(topicID, request);

        if (result == false)
            return NotFound();

        return Ok();
    }

    [HttpDelete("{topicID:Guid}")]
    public async Task<ActionResult> Delete(Guid topicID)
    {
        var result = await _topicRepository.DeleteAsync(topicID);

        if (result == false)
            return NotFound();

        return Ok();
    }
}
