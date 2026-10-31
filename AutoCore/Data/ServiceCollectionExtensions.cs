using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AutoCore.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAutoCoreData(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AutoCoreDbContext>(options => options.UseNpgsql(connectionString));

        return services;
    }
}