using MicroService.Infrastructure.Data;
using MicroService.Infrastructure.Repository;
using MicroServiceAPI.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace MicroService.Infrastructure
{
    public static class ConfigrationService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration Configuration)
        {

            var connectionString = Configuration.GetConnectionString("BlogDbContext")
                ?? throw new ArgumentNullException("BlogDbContext", "Connection string 'BlogDbContext' is missing from configuration.");


            // Register DbContext
            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connectionString));

            // Register blog repository
            services.AddTransient<IblogRepository, blogRepository>();


            return services;
        }
    }
}
