using EducationalWebService.Data.Context;
using EducationalWebService.Data.Models;
using EducationalWebService.Logic.DTO.Mappers;
using EducationalWebService.Logic.DTO.Topic;
using EducationalWebService.Logic.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EducationalWebService.Logic.Repository;

public class TopicRepository : ITopicRepository
{
    private readonly EducationalWebServiceContext _db;

    public TopicRepository(EducationalWebServiceContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<TopicDTO>> GetAllByGameIDAsync(Guid gameID)
    {
        var result = await _db.JeopardyTopic
            .Where(topic => topic.GameID == gameID)
            .Select(topic => TopicMapper.ToDTO(topic))
            .ToListAsync();

        //if (result.Count == 0) return null;

        return result;
    }

    public async Task<TopicDTO?> GetByIDAsync(Guid topicID)
    {
        var result = await _db.JeopardyTopic.FindAsync(topicID);

        if (result == null) return null;

        return TopicMapper.ToDTO(result);
    }

    public async Task<TopicDTO> CreateAsync(Guid gameID, TopicRequest request)
    {
        var modelObject = TopicMapper.ToModelObject(gameID, request);

        await _db.JeopardyTopic.AddAsync(modelObject);

        await _db.SaveChangesAsync();

        return TopicMapper.ToDTO(modelObject);
    }

    public async Task<bool> UpdateAsync(Guid topicID, TopicRequest request)
    {
        var topic = await _db.JeopardyTopic.FindAsync(topicID);

        if (topic == null) return false;

        topic.Title = request.Title;
        topic.Round = request.Round;

        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ClearAsync(Guid topicID)
    {
        var questionsToDelte = _db.JeopardyQuestion
            .Where(question => question.TopicID == topicID);

        _db.JeopardyQuestion.RemoveRange(questionsToDelte);

        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(Guid topicID)
    {
        var topic = await _db.JeopardyTopic.FindAsync(topicID);

        if (topic == null) return false;

        _db.JeopardyTopic.Remove(topic);

        await _db.SaveChangesAsync();

        return true;
    }
}
