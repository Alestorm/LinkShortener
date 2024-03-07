using LinkShortener.EFCore.DatabaseContext;
using LinkShortener.Entities;
using LinkShortener.Entities.Constants;
using LinkShortener.Entities.Entities;
using LinkShortener.Entities.Errors;
using LinkShortener.Entities.Interfaces.LinkContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.EFCore.Repositories.LinkRepositories
{
    public class CreateLinkRepository : ICreateLink
    {
        private readonly AppDbContext _context;
        public CreateLinkRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Response> CreateLink(Link link)
        {
            try
            {
                var user = await _context.Users.Where(u => u.IdUser == link.IdUser).FirstOrDefaultAsync();
                user?.LinkList.Add(link);
                _context.Links.Add(link);
                await _context.SaveChangesAsync();
                return ResponseFactory.CreateResponse(201, HttpCodes.ResponseMap[201], data: link);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return ResponseFactory.CreateResponse(500, HttpCodes.ResponseMap[500], error: LinkErrors.DatabaseError);
            }
        }
    }
}
