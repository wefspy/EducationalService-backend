﻿using EducationalWebService.Data.Context;
using EducationalWebService.Data.Models;
using EducationalWebService.Logic.DTO.Mappers;
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
            .Select(question => QuestionMapper.ModelObjectToDTO(question))
            .ToListAsync();

        return result;
    }

    public async Task<QuestionDTO?> GetbyIDAsync(Guid questionID)
    {
        var result = await _db.JeopardyQuestion.FindAsync(questionID);

        if (result == null) return null;

        return QuestionMapper.ModelObjectToDTO(result);
    }


    public async Task<QuestionDTO> CreateAsync(Guid topicID, QuestionRequest request)
    {
        var modelObject = QuestionMapper.RequestToModelObject(topicID, request);

        await _db.JeopardyQuestion.AddAsync(modelObject);

        await _db.SaveChangesAsync();

        return QuestionMapper.ModelObjectToDTO(modelObject);
    }

    public async Task<bool> UpdateAsync(Guid questionID, QuestionRequest request)
    {
        var question = await _db.JeopardyQuestion.FindAsync(questionID);

        if (question == null) return false;

        question.Text = request.Text;
        question.ImagePath = request.Image;
        question.MusicPath = request.Music;
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
