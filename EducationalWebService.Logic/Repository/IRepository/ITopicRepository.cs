using EducationalWebService.Logic.DTO.Topic;

namespace EducationalWebService.Logic.Repository.IRepository;

public interface ITopicRepository
{
    public Task<IEnumerable<TopicDTO>?> GetAllByGameIDAsync(Guid gameID);

    public Task<TopicDTO?> GetByIDAsync(Guid topicID);

    public Task<bool> CreateAsync(Guid gameID, TopicRequest request);

    public Task<bool> UpdateAsync(Guid topicID, TopicRequest request);

    public Task<bool> DeleteAsync(Guid topicID);
}
