using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Repositories;
using Domain.Repositories;


namespace Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<INoteRepository, NoteRepository>();
        }
    }
}
