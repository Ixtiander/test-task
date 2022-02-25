using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestApplication.DAL;

namespace TestApplication.BL.Utils
{
    public static class ApplicationDbContextExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options
                    .UseNpgsql(connectionString)
                    .UseSnakeCaseNamingConvention()
                );
        }
    }
}