using LinkShortener.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Entities.Interfaces.UserContracts
{
    public interface IAuthenticateUser
    {
        Task<Response> AuthenticateByUsername(string username, string password);
        Task<Response> AuthenticateByEmail(string email, string password);
    }
}
