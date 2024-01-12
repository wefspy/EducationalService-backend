using EducationalWebService.Logic.Generator.IGenerator;

namespace EducationalWebService.Logic.Generator;

public class SessionCodeGenerator : ISessionCodeGenerator
{
    public string GenerateSessionCode(int length)
    {
        var guid = Guid.NewGuid().ToString("N").ToUpper(); // N - String without delimiters

        return guid[..length];
    }
}
