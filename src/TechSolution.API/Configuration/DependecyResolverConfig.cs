using Microsoft.Extensions.DependencyInjection;
using TechSolution.Business.Interfaces;
using TechSolution.Business.Notifications;
using TechSolution.Business.Services;
using TechSolution.Data.Context;
using TechSolution.Data.Repositories;

namespace TechSolution.API.Configuration
{
    public static class DependecyResolverConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<TechSolutionDbContext>();
            services.AddScoped<INotificator, Notificator>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IQuestionService, QuestionService>();
            return services;
        }
    }
}
