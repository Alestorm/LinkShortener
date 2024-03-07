using LinkShortener.EFCore.DatabaseContext;
using LinkShortener.Entities;
using LinkShortener.Entities.Constants;
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
    public class GetShortUrlRepository : IGetShortUrl
    {
        private readonly AppDbContext _context;
        public GetShortUrlRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Response> GetShortUrl(string code)
        {
            try
            {
                var shortUrl = await _context.Links.Where(l => l.Code.Equals(code)).FirstOrDefaultAsync();
                return shortUrl != null ? ResponseFactory.CreateResponse(200, HttpCodes.ResponseMap[200], data: shortUrl) : ResponseFactory.CreateResponse(404, HttpCodes.ResponseMap[404], error: LinkErrors.NotFoundLink);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return ResponseFactory.CreateResponse(500, HttpCodes.ResponseMap[500], error: LinkErrors.DatabaseError);
            }
        }
    }
}
