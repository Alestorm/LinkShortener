using LinkShortener.DTOS.UserDtos;
using LinkShortener.Entities;
using LinkShortener.Entities.Entities;
using LinkShortener.Entities.Interfaces.UserContracts;
using LinkShortener.Helpers;
using LinkShortener.Mappers.UserMappers;
using LinkShortener.UseCases.UserUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.UseCases.UserUseCases.Services
{
    public class AuthenticatUserService : IAuthenticateUserService
    {
        private readonly IAuthenticateUser _authenticateUser;
        public AuthenticatUserService(IAuthenticateUser authenticateUser)
        {
            _authenticateUser = authenticateUser;
        }
        public async Task<Response> AuthenticateByEmail(string email, string password)
        {
            password = Encrypter.EncryptPassword(password);
            var response = await _authenticateUser.AuthenticateByEmail(email, password);
            if (response.Status == 200)
            {
                response.Data = UserMapper.DbToUserDto((response.Data as User));
            }
            return response;
        }

        public async Task<Response> AuthenticateByUsername(string username, string password)
        {
            password = Encrypter.EncryptPassword(password);
            var response = await _authenticateUser.AuthenticateByUsername(username, password);
            if (response.Status == 200)
            {
                response.Data = UserMapper.DbToUserDto((response.Data as User));
            }
            return response;
        }
    }
}
