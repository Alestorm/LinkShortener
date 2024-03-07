using LinkShortener.EFCore.DatabaseContext;
using LinkShortener.Entities;
using LinkShortener.Entities.Constants;
using LinkShortener.Entities.Entities;
using LinkShortener.Entities.Errors;
using LinkShortener.Entities.Interfaces.UserContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.EFCore.Repositories.UserRepositories
{
    public class GetUserListRepository : IGetUserList
    {
        private readonly AppDbContext _context;
        public GetUserListRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Response> GetUsers()
        {
            try
            {
                var userList = await _context.Users.ToListAsync();
                return userList.Count > 0 ? ResponseFactory.CreateResponse(200, HttpCodes.ResponseMap[200], data: userList) :
                    ResponseFactory.CreateResponse(204, HttpCodes.ResponseMap[204], error: UserErrors.NoUsers);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return ResponseFactory.CreateResponse(500, HttpCodes.ResponseMap[500], error: UserErrors.DatabaseError);
            }
        }
    }
}
