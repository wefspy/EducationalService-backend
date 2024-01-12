using EducationalWebService.Logic.DTO.User;
using EducationalWebService.Logic.Repository.IRepository;
using EducationalWebService.Data.Context;
using EducationalWebService.Data.Models;
using EducationalWebService.Logic.Generator.IGenerator;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace EducationalWebService.Logic.Repository;

public class UserRepository : IUserRepository
{
    private readonly EducationalWebServiceContext _db;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    
    public UserRepository(EducationalWebServiceContext db, UserManager<User> userManager,
        SignInManager<User> signInManager, IJwtTokenGenerator jwtTokenGenerator)
    {
        _db = db;
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<UserResponse> RegisterAsync(UserRegistrationRequest request)
    {
        // TODO Attach roles to created users
        var isValidEmail = Regex.IsMatch(request.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        if (!isValidEmail)
            return new UserResponse(Guid.Empty, "", new List<IdentityError>() { new IdentityError()
                { Code = "Unprocessable entity", Description = "Invalid email address" } });

        var user = _db.User.FirstOrDefault(u => u.UserName == request.Name);

        if (user != null)
            return new UserResponse(Guid.Empty, "", new List<IdentityError>() { new IdentityError() 
                { Code = "Conflict", Description = "This login is already in use" } });

        user = new User
        {
            UserName = request.Name,
            Email = request.Email,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return new UserResponse(Guid.Empty, "", result.Errors);

        var token = _jwtTokenGenerator.GenerateUserJwtToken(user);

        return new UserResponse(user.Id, token, new List<IdentityError>());
    }

    public async Task<UserResponse> SignInAsync(UserSignInRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.Name);

        if (user == null)
            return new UserResponse(Guid.Empty, "", new List<IdentityError>() { new IdentityError()
                { Code = "Unprocessable entity", Description = "Invalid login" } });

        var result = await _signInManager.PasswordSignInAsync(request.Name, request.Password, false, false);

        if (!result.Succeeded)
            return new UserResponse(Guid.Empty, "", new List<IdentityError>() { new IdentityError()
                { Code = "Unprocessable entity", Description = "Invalid password" } });

        var token = _jwtTokenGenerator.GenerateUserJwtToken(user!);

        return new UserResponse(user.Id, token, new List<IdentityError>());
    }
}
