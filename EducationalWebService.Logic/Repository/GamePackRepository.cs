using EducationalWebService.Logic.DTO.GamePack;
using EducationalWebService.Logic.DTO.Question;
using EducationalWebService.Logic.Repository.IRepository;
using System.Runtime.CompilerServices;

namespace EducationalWebService.Logic.Repository;

public class GamePackRepository : IGamePackRepository
{
    private readonly IGameRepository _gameRepository;
    private readonly ITopicRepository _topicRepository;
    private readonly IQuestionRepository _questionRepository;

    public GamePackRepository(IGameRepository gameRepository, ITopicRepository topicRepository, 
        IQuestionRepository questionRepository)
    {
        _gameRepository = gameRepository;
        _topicRepository = topicRepository;
        _questionRepository = questionRepository;
    }

    public async Task<GamePackDTO?> GetByGameIDAsync(Guid gameID)
    {
        var game = await _gameRepository.GetByIDAsync(gameID);

        if (game == null) 
            return null;

        var topics = await _topicRepository.GetAllByGameIDAsync(gameID);

        var topicPacks = new List<TopicPackDTO>();

        topics.Select(async topic =>
            topicPacks.Add(new TopicPackDTO()
            {
                Topic = topic,
                QuestionPack = await _questionRepository.GetAllByTopicIDAsync(topic.TopicID)
            }));

        return new GamePackDTO() { Game = game, TopicPacks = topicPacks };
    }

    public async Task<GamePackDTO> CreateAsync(Guid userID, GamePackRequest request)
    {
        var game = await _gameRepository.CreateAsync(userID, request.Game);

        var topicPacks = new List<TopicPackDTO>();

        foreach (var topicPack in request.TopicPacks)
        {
            var questionPack = new List<QuestionDTO>();

            var topic = await _topicRepository.CreateAsync(game.GameID, topicPack.Topic);

            topicPack.QuestionPack.Select(async question =>
                questionPack.Add(await _questionRepository.CreateAsync(topic.TopicID, question)));

            topicPacks.Add(new TopicPackDTO() { Topic = topic, QuestionPack = questionPack });
        }

        return new GamePackDTO() { Game = game, TopicPacks = topicPacks };
    }

    public async Task<bool> UpdateAsync(Guid gameID, GamePackRequest request)
    {
        //var game = await _gameRepository.GetByIDAsync(gameID);

        //if (game == null) 
        //    return false;
        throw new NotImplementedException();
        
    }

    public async Task<bool> DeleteAsync(Guid gameID)
    {
        await _gameRepository.DeleteAsync(gameID);

        return true;
    }   
}
