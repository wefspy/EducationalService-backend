using EducationalWebService.Logic.DTO.Question;
using EducationalWebService.Logic.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

namespace EducationalWebService.API.Controllers;

[Authorize]
[Route("api/{userID:Guid}/jeopardy/{gameID:Guid}/topic/{topicID:Guid}/question")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionRepository _questionRepository;
    public QuestionController(IQuestionRepository questionRepository) 
    {
        _questionRepository = questionRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetAllByTopicID([FromRoute] Guid topicID)
    {
        var result = await _questionRepository.GetAllByTopicIDAsync(topicID);

        return Ok(result);
    }

    [HttpGet("{questionID:Guid}")]
    public async Task<ActionResult<QuestionDTO?>> GetbyID(Guid questionID)
    {
        var result = await _questionRepository.GetbyIDAsync(questionID);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromRoute] Guid topicID, QuestionRequest request)
    {
        var isOk = await _questionRepository.CreateAsync(topicID, request);

        if (isOk)
            return Ok();

        return BadRequest();
    }

    [HttpPut("{questionID:Guid}")]
    public async Task<ActionResult> Update([FromRoute] Guid questionID, QuestionRequest request)
    {
        var isOk = await _questionRepository.UpdateAsync(questionID, request);

        if (isOk)
            return Ok();

        return NotFound();
    }

    [HttpDelete("{questionID:Guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid questionID)
    {
        var isOk = await _questionRepository.DeleteAsync(questionID);

        if (isOk)
            return Ok();

        return NotFound();
    }
}
