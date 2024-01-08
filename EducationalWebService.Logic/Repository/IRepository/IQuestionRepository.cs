using EducationalWebService.Logic.DTO.Question;
using EducationalWebService.Logic.DTO.User;

namespace EducationalWebService.Logic.Repository.IRepository;

public interface IQuestionRepository
{
    public Task<IEnumerable<QuestionDTO>> GetAllByTopicIDAsync(Guid topicID);

    public Task<QuestionDTO?> GetbyIDAsync(Guid questionID);

    public Task<bool> CreateAsync(Guid topicID, QuestionRequest request);

    public Task<bool> UpdateAsync(Guid questionID, QuestionRequest request);

    public Task<bool> DeleteAsync(Guid questionID);
}
