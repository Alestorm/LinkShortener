using LinkShortener.EFCore.DatabaseContext;
using LinkShortener.Entities;
using LinkShortener.Entities.Constants;
using LinkShortener.Entities.Entities;
using LinkShortener.Entities.Errors;
using LinkShortener.Entities.Interfaces.UserContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.EFCore.Repositories.UserRepositories
{
    public class RegisterUserRepository : IRegisterUser
    {
        private readonly AppDbContext _context;
        public RegisterUserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Response> RegisterUser(User user)
        {
            try
            {
                if (_context.Users.Any(u => u.Username.Equals(user.Username)
                                        || u.Email.Equals(user.Email)))
                {
                    return ResponseFactory.CreateResponse(409, HttpCodes.ResponseMap[409], error: UserErrors.AlreadyExists);
                }
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return ResponseFactory.CreateResponse(201, HttpCodes.ResponseMap[201], data: user);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return ResponseFactory.CreateResponse(500, HttpCodes.ResponseMap[500], error: UserErrors.DatabaseError);
            }
        }
    }
}
