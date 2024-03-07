using LinkShortener.EFCore.DatabaseContext;
using LinkShortener.EFCore.Repositories.LinkRepositories;
using LinkShortener.EFCore.Repositories.UserRepositories;
using LinkShortener.Entities.Interfaces.LinkContracts;
using LinkShortener.Entities.Interfaces.UserContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.EFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("LinkShortener.EFCore"));
            });

            #region UserServices
            services.AddScoped<IAuthenticateUser, AuthenticateUserRepository>();
            services.AddScoped<IRegisterUser, RegisterUserRepository>();
            services.AddScoped<IGetUserList, GetUserListRepository>();
            services.AddScoped<IGetLinks, GetLinksRepository>();
            #endregion

            #region LinkServices
            services.AddScoped<ICreateLink, CreateLinkRepository>();
            services.AddScoped<ICheckUniqueCode, CheckUniqueCodeRepository>();
            services.AddScoped<IGetShortUrl, GetShortUrlRepository>();
            services.AddScoped<IUpdateFrequency, UpdateFrequencyRepository>();
            services.AddScoped<IGetLinkInfo, GetLinkInfoRepository>();
            #endregion


            return services;
        }
    }
}
