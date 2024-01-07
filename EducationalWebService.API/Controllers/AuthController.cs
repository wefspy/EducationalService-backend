using Microsoft.AspNetCore.Mvc;
using EducationalWebService.Logic.Repository.IRepository;
using EducationalWebService.Logic.DTO.User;
using Microsoft.AspNetCore.Identity;
using EducationalWebService.Data.Models;


namespace EducationalWebService.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public AuthController(IUserRepository userService)
    {
        _userRepository = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Registration(UserRegistrationRequest request)
    {
        var response = await _userRepository.RegisterAsync(request);

        if (response == null)
            return BadRequest();

        return Ok(response);
    }

    //[httppost("signin")]
    //public async task<iactionresult> signin(usersigninrequest request)
    //{
    //    var response = await _userrepository.signinasync(request);

    //    if (response == null)
    //        return badrequest();

    //    return ok(response);
    //}
}
