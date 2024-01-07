using EducationalWebService.Logic.DTO.User;

namespace EducationalWebService.Logic.Repository.IRepository;

public interface IUserRepository
{
    public Task<UserRegistrationResponse?> RegisterAsync(UserRegistrationRequest request);

    public Task<UserSignInResponse?> SignInAsync(UserSignInRequest request);
}
