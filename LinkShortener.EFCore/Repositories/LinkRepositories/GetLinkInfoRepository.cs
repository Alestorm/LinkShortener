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
    public class GetLinkInfoRepository : IGetLinkInfo
    {
        private readonly AppDbContext _context;
        public GetLinkInfoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Response> GetLinkInfo(string shorturl)
        {
            try
            {
                var link = await _context.Links.Where(l => l.ShortUrl.Equals(shorturl)).FirstOrDefaultAsync();
                return link != null ? ResponseFactory.CreateResponse(200, HttpCodes.ResponseMap[200], data: link) :
                    ResponseFactory.CreateResponse(404, HttpCodes.ResponseMap[404], error: LinkErrors.NotFoundLink);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return ResponseFactory.CreateResponse(500, HttpCodes.ResponseMap[500], error: LinkErrors.DatabaseError);
            }
        }
    }
}
