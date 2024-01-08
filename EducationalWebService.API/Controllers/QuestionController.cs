using EducationalWebService.Logic.DTO.Question;
using EducationalWebService.Logic.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationalWebService.API.Controllers
{
    [Route("api/jeopardy/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionController(IQuestionRepository questionRepository) 
        {
            _questionRepository = questionRepository;
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<QuestionDTO>> GetById(Guid id)
        {
            var result = await _questionRepository.GetAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
