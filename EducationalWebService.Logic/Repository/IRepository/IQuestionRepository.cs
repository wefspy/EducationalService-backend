using EducationalWebService.Logic.DTO.Question;
using EducationalWebService.Logic.DTO.User;

namespace EducationalWebService.Logic.Repository.IRepository;

public interface IQuestionRepository
{
    public Task<QuestionDTO?> GetAsync(Guid questionID);

    public Task<bool> CreateAsync(Guid topicID);

    public Task<bool> UpdateAsync(Guid questionID);

    public Task<bool> DeleteAsync(Guid questionID);
}
