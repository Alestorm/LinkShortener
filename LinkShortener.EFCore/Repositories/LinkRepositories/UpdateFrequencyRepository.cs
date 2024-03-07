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
    public class UpdateFrequencyRepository : IUpdateFrequency
    {
        private readonly AppDbContext _context;
        public UpdateFrequencyRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Response> UpdateFrequency(string code)
        {
            try
            {
                var link = await _context.Links.Where(l => l.Code.Equals(code)).FirstOrDefaultAsync();
                if (link == null)
                {
                    return ResponseFactory.CreateResponse(404, HttpCodes.ResponseMap[404], error: LinkErrors.NotFoundLink);
                }
                link.Frequency++;
                await _context.SaveChangesAsync();
                return ResponseFactory.CreateResponse(200, HttpCodes.ResponseMap[200]);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return ResponseFactory.CreateResponse(500, HttpCodes.ResponseMap[500], error: LinkErrors.DatabaseError);
            }
        }
    }
}
