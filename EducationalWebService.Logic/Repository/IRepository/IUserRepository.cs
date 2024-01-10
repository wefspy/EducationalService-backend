using EducationalWebService.Logic.DTO.User;

namespace EducationalWebService.Logic.Repository.IRepository;

public interface IUserRepository
{
    public Task<UserResponse> RegisterAsync(UserRegistrationRequest request);

    public Task<UserResponse> SignInAsync(UserSignInRequest request);
}
