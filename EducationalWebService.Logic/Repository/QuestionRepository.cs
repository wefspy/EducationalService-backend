using EducationalWebService.Data.Context;
using EducationalWebService.Data.Models;
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

    public async Task<IEnumerable<QuestionDTO>> GetAllByTopicIDAsync(Guid topicID)
    {
        var result = await _db.JeopardyQuestion
            .Where(question => question.TopicID == topicID)
            .Select(question => QuestionMapper.ToDTO(question))
            .ToListAsync();

        return result;
    }

    public async Task<QuestionDTO?> GetbyIDAsync(Guid questionID)
    {
        var result = await _db.JeopardyQuestion.FindAsync(questionID);

        if (result == null) return null;

        return QuestionMapper.ToDTO(result);
    }


    public async Task<bool> CreateAsync(Guid topicID, QuestionRequest request)
    {
        await _db.JeopardyQuestion.AddAsync(new JeopardyQuestion
        {
            TopicID = topicID,
            Text = request.Text,
            imagePath = request.Image,
            musicPath = request.Music,
            Reward = request.Reward,
            Answer = request.Answer,
        });

        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(Guid questionID, QuestionRequest request)
    {
        var question = await _db.JeopardyQuestion.FindAsync(questionID);

        if (question == null) return false;

        question.Text = request.Text;
        question.imagePath = request.Image;
        question.musicPath = request.Music;
        question.Reward = request.Reward;
        question.Answer = request.Answer;

        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(Guid questionID)
    {
        var question = await _db.JeopardyQuestion.FindAsync(questionID);

        if (question == null) return false;

        _db.JeopardyQuestion.Remove(question);

        await _db.SaveChangesAsync();

        return true;
    }   
}
