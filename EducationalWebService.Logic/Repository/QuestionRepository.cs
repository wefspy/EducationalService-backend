using EducationalWebService.Data.Context;
using EducationalWebService.Logic.DTO.MappersToDTO;
using EducationalWebService.Logic.DTO.Question;
using EducationalWebService.Logic.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EducationalWebService.Logic.Repository;

public class QuestionRepository : IQuestionRepository
{
    private readonly EducationalWebServiceContext _db;

    public QuestionRepository(EducationalWebServiceContext db)
    {
        _db = db;
    }

    public async Task<QuestionDTO?> GetAsync(Guid questionID)
    {
        var result = await _db.JeopardyQuestion.FindAsync(questionID);

        if (result == null) return null;

        return QuestionMapper.ToDTO(result);
    }

    public Task<bool> CreateAsync(Guid topicID)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid questionID)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Guid questionID)
    {
        throw new NotImplementedException();
    }
}
