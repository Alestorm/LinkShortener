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
    public class AuthenticateUserRepository : IAuthenticateUser
    {
        private readonly AppDbContext _context;
        public AuthenticateUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AuthenticateByEmail(string email, string password)
        {
            try
            {
                var user = await _context.Users.Where(u => u.Email.Equals(email) && u.Password.Equals(password)).FirstOrDefaultAsync();
                if (user == null)
                {
                    return ResponseFactory.CreateResponse(401, HttpCodes.ResponseMap[401], error: UserErrors.Unauthorized);
                }
                return ResponseFactory.CreateResponse(200, HttpCodes.ResponseMap[200], data: user);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return ResponseFactory.CreateResponse(500, HttpCodes.ResponseMap[500], error: UserErrors.DatabaseError);
            }
        }

        public async Task<Response> AuthenticateByUsername(string username, string password)
        {
            try
            {
                var user = await _context.Users.Where(u => u.Username.Equals(username) && u.Password.Equals(password)).FirstOrDefaultAsync();
                if (user == null)
                {
                    return ResponseFactory.CreateResponse(401, HttpCodes.ResponseMap[401], error: UserErrors.Unauthorized);
                }
                return ResponseFactory.CreateResponse(200, HttpCodes.ResponseMap[200], data: user);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return ResponseFactory.CreateResponse(500, HttpCodes.ResponseMap[500], error: UserErrors.DatabaseError);
            }
        }
    }
}
