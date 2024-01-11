﻿using EducationalWebService.Logic.DTO.User;
using EducationalWebService.Logic.Repository.IRepository;
using EducationalWebService.Data.Context;
using EducationalWebService.Data.Models;
using EducationalWebService.Logic.Generator.IGenerator;
using Microsoft.AspNetCore.Identity;

namespace EducationalWebService.Logic.Repository;

public class UserRepository : IUserRepository
{
    private readonly EducationalWebServiceContext _db;
    private readonly UserManager<User> _userManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    
    public UserRepository(EducationalWebServiceContext db, UserManager<User> userManager,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _db = db;
        _userManager = userManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<UserResponse> RegisterAsync(UserRegistrationRequest request)
    {
        // TODO Attach roles to created users

        var user = _db.User.FirstOrDefault(u => u.UserName == request.Name);

        if (user != null)
            return new UserResponse(Guid.Empty, "", new List<IdentityError>() { new IdentityError() 
                { Code = "Unprocessable Entity", Description = "This login is already in use" } });

        user = new User
        {
            UserName = request.Name,
            Email = request.Email,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return new UserResponse(Guid.Empty, "", result.Errors);

        var token = await _jwtTokenGenerator.GenerateUserJwtTokenAsync(user);

        return new UserResponse(user.Id, token, new List<IdentityError>());
    }

    public Task<UserResponse> SignInAsync(UserSignInRequest request)
    {
        throw new NotImplementedException();
    }
}
