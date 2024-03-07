using LinkShortener.DTOS.UserDtos;
using LinkShortener.Entities;
using LinkShortener.Entities.Entities;
using LinkShortener.Entities.Interfaces.UserContracts;
using LinkShortener.Mappers.UserMappers;
using LinkShortener.UseCases.UserUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.UseCases.UserUseCases.Services
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IRegisterUser _registerUser;
        public RegisterUserService(IRegisterUser registerUser)
        {
            _registerUser = registerUser;
        }
        public async Task<Response> RegisterUser(RegisterUserDto registerUserDto)
        {
            var response = await _registerUser.RegisterUser(UserMapper.RegisterDtoToDb(registerUserDto));
            if (response.Data != null)
            {
                var user = response.Data as User;
                response.Data = UserMapper.DbToUserDto(user);
            }
            return response;
        }
    }
}
