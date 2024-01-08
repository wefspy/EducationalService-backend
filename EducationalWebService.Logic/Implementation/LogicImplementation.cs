using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using EducationalWebService.Logic.Generator.IGenerator;
using EducationalWebService.Logic.Generator;
using EducationalWebService.Logic.Repository.IRepository;
using EducationalWebService.Logic.Repository;
using EducationalWebService.Data.Models;

namespace EducationalWebService.Logic.Implementation;

public static class LogicImplementation
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IQuestionRepository, QuestionRepository>();

        return services;
    }

    public static IServiceCollection AddGenerators(this IServiceCollection services)
    {
        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }

    //public static iservicecollection configureidentity(this iservicecollection services)
    //{
    //    services
    //        .addidentity<user, role>()
    //        .addentityframeworkstores<educationalwebservicecontext>()
    //        .adddefaulttokenproviders();
    //
    //    return services;
    //}
}
