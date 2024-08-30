using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TaskBox.Infra.Data.Context
{
    public static class ContextRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskBoxDbContext>(options =>
           options.UseSqlServer(
               configuration.GetConnectionString("TaskBoxDatabase"),
               b => b.MigrationsAssembly(typeof(TaskBoxDbContext).Assembly.FullName)));
        }
    }
}
