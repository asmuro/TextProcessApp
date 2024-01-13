using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC
{
    public static class IoCExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<ITextProcessApplicationService, TextProcessApplicationService>();
        }
    }
}
