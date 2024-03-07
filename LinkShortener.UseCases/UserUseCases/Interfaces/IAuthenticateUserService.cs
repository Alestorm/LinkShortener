using LinkShortener.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.UseCases.UserUseCases.Interfaces
{
    public interface IAuthenticateUserService
    {
        Task<Response> AuthenticateByUsername(string username, string password);
        Task<Response> AuthenticateByEmail(string email, string password);
    }
}
