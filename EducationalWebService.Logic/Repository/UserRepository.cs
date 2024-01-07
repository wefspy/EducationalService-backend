﻿using Microsoft.AspNetCore.Identity;
using EducationalWebService.Data.Models;
using EducationalWebService.Logic.DTO.User;
using EducationalWebService.Logic.Repository.IRepository;
using EducationalWebService.Logic.Generator.IGenerator;
using EducationalWebService.Data.Context;

namespace EducationalWebService.Logic.Repository;

public class UserRepository : IUserRepository
{
    private readonly EducationalWebServiceContext _db;
    private readonly UserManager<User> _userManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    

    public UserRepository(EducationalWebServiceContext db, UserManager<User> userManager, IJwtTokenGenerator jwtTokenGenerator
        )
    {
        _db = db;
        _userManager = userManager;
        _jwtTokenGenerator = jwtTokenGenerator;

    }

    public async Task<UserRegistrationResponse?> RegisterAsync(UserRegistrationRequest request)
    {
        // TODO: Return an error message

        var user = _db.Users.FirstOrDefault(u => u.Name == request.Name); // Not optimized

        if (user != null) // Name already exists
            return null;

        user = new User
        {
            UserName = request.Name,
            Name = request.Name,
            Email = request.Email,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return null;

        var token = await _jwtTokenGenerator.GenerateUserJwtTokenAsync(user);

        var response = new UserRegistrationResponse(user.Id, token);
   
        return response;
    }

    public async Task<UserSignInResponse?> SignInAsync(UserSignInRequest request)
    {
        throw new NotImplementedException();

        //var user = _db.Users.FirstOrDefault(u => u.Name == request.Name);

        //if (user == null) // User does not exist
        //    return null;

    }
}