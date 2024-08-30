using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TaskBox.Infra.Data.Context.Configurations
{
    public static class ContextConfiguration
    {
        public static void RunMigration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                 .GetRequiredService<IServiceScopeFactory>()
                 .CreateScope();

            using var context = serviceScope.ServiceProvider.GetService<TaskBoxDbContext>();

            if (context != null)
            {
                context.Database.Migrate();
            }
        }
    }
}
