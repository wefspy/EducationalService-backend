using EducationalWebService.Data.Models;

namespace EducationalWebService.Logic.Generator.IGenerator;

public interface IJwtTokenGenerator
{
    public string GenerateUserJwtToken(User user);
}
