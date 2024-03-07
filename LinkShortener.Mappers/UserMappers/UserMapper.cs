using LinkShortener.DTOS.UserDtos;
using LinkShortener.Entities.Entities;
using LinkShortener.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Mappers.UserMappers
{
    public static class UserMapper
    {
        public static User RegisterDtoToDb(RegisterUserDto registerUserDto)
        {
            registerUserDto.Password = Encrypter.EncryptPassword(registerUserDto.Password);

            return new User
            {
                Name = registerUserDto.Name,
                Lastname = registerUserDto.Lastname,
                Email = registerUserDto.Email,
                Username = registerUserDto.Username,
                Password = registerUserDto.Password,
                IsActive = true,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
            };
        }

        public static UserDto DbToUserDto(User user)
        {
            return new UserDto
            {
                IdUser = user.IdUser,
                Name = user.Name,
                Lastname = user.Lastname,
                Email = user.Email,
                Username = user.Username,
                IsActive = user.IsActive,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
            };
        }
    }
}