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
    public class GetUserListService : IGetUserListService
    {
        private readonly IGetUserList _getUserList;
        public GetUserListService(IGetUserList getUserList)
        {
            _getUserList = getUserList;
        }
        public async Task<Response> GetUsers()
        {
            var response = await _getUserList.GetUsers();
            if (response.Status == 200)
            {
                var userList = (response.Data as List<User>);
                response.Data = userList.Select(u => UserMapper.DbToUserDto(u)).ToList();
            }
            return response;
        }
    }
}