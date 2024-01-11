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

    public AuthController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
        var response = await _userRepository.SignInAsync(request);

        if (response.id == Guid.Empty)
            return BadRequest(response);

        return Ok(response);
    }
}
