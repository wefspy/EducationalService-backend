using Microsoft.AspNetCore.Mvc;
using EducationalWebService.Logic.Repository.IRepository;
using EducationalWebService.Logic.DTO.User;
using Microsoft.AspNetCore.Identity;
using EducationalWebService.Data.Models;
using EducationalWebService.Logic.Generator.IGenerator;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;


namespace EducationalWebService.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;


    public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, 
        IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;

        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserResponse>> Registration(UserRegistrationRequest request)
    {
        var response = await _userRepository.RegisterAsync(request);

        if (response.id == Guid.Empty)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("signin")]
    public async Task<ActionResult<UserResponse>> SignIn(UserSignInRequest request)
    {
        // TODO Transfer to UserRepository

        var result = await _signInManager.PasswordSignInAsync(request.Name, request.Password, false, false);

        if (!result.Succeeded)
            return Forbid();

        var user = await _userManager.FindByNameAsync(request.Name);

        if (user == null)
            return Forbid();

        var token = await _jwtTokenGenerator.GenerateUserJwtTokenAsync(user!);

        return Ok(new UserResponse(user.Id, token, new List<IdentityError>()));
    }
}
