using EducationalWebService.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EducationalWebService.Logic.Implementation;

public static class DbImplementation
{
    public static IServiceCollection AddDataBase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<EducationalWebServiceContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }
}
