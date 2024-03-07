using LinkShortener.UseCases.LinkUseCases.Interfaces;
using LinkShortener.UseCases.LinkUseCases.Services;
using LinkShortener.UseCases.UserUseCases.Interfaces;
using LinkShortener.UseCases.UserUseCases.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LinkShortener.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticateUserService, AuthenticatUserService>();
            services.AddTransient<IGetUserListService, GetUserListService>();
            services.AddTransient<IRegisterUserService, RegisterUserService>();
            services.AddTransient<IGetLinksService, GetLinksService>();
            

            services.AddTransient<ICreateLinkService, CreateLinkService>();
            services.AddTransient<IGetShortUrlService, GetShortUrlService>();
            services.AddTransient<IUpdateFrequencyService, UpdateFrequencyService>();
            services.AddTransient<IGetLinkInfoService, GetLinkInfoService>();

            return services;
        }
    }
}