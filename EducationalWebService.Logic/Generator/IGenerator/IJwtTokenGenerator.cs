using EducationalWebService.Data.Models;

namespace EducationalWebService.Logic.Generator.IGenerator;

public interface IJwtTokenGenerator
{
    public Task<string> GenerateUserJwtTokenAsync(User user);
}
