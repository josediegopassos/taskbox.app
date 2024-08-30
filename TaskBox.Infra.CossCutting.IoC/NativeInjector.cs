using Microsoft.Extensions.DependencyInjection;
using TaskBox.Application.Interfaces;
using TaskBox.Application.Services;
using TaskBox.Domain.Interfaces;
using TaskBox.Domain.Interfaces.Repositories;
using TaskBox.Domain.Interfaces.Repositories.Base;
using TaskBox.Domain.Interfaces.Services;
using TaskBox.Domain.Interfaces.Validation;
using TaskBox.Domain.Notifications;
using TaskBox.Domain.Services;
using TaskBox.Domain.Validation.Task;
using TaskBox.Infra.CrossCutting.Logger;
using TaskBox.Infra.CrossCutting.Logger.Interfaces;
using TaskBox.Infra.Data.Repositories;
using TaskBox.Infra.Data.Repositories.Base;
using TaskBox.Infra.Data.UoW;

namespace TaskBox.Infra.CossCutting.IoC
{
    public static class NativeInjector
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            RegisterInfraServices(services);
            RegisterDomainServices(services);
            RegisterApplicationServices(services);

            return services;
        }

        private static void RegisterInfraServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IListTaskRepository, ListTaskRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILoggerService, LoggerService>();
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddScoped<IHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskService, TaskService>();

            services.AddScoped<IRegisterValidation<Domain.Models.Task>, CreateTaskValidation>();
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
           services.AddScoped<ITaskAppService, TaskAppService>();
           services.AddScoped<IUserAppService, UserAppService>();
        }
    }
}
