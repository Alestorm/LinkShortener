using LinkShortener.EFCore.DatabaseContext;
using LinkShortener.Entities;
using LinkShortener.Entities.Constants;
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
    public class GetLinksRepository : IGetLinks
    {
        private readonly AppDbContext _context;
        public GetLinksRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Response> GetLinks(int idUser)
        {
            try
            {
                var userLinks = await _context.Users.Include(u => u.LinkList).FirstOrDefaultAsync(u => u.IdUser == idUser);
                return userLinks != null && userLinks.LinkList.Count > 0 ? ResponseFactory.CreateResponse(200, HttpCodes.ResponseMap[200], data: userLinks) :
                    ResponseFactory.CreateResponse(404, HttpCodes.ResponseMap[404], data: LinkErrors.LinkListEmpty);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return ResponseFactory.CreateResponse(500, HttpCodes.ResponseMap[500], error: LinkErrors.DatabaseError);
            }
        }
    }
}
