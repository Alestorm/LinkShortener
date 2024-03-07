using LinkShortener.EFCore.DatabaseContext;
using LinkShortener.Entities;
using LinkShortener.Entities.Interfaces.LinkContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.EFCore.Repositories.LinkRepositories
{
    public class CheckUniqueCodeRepository : ICheckUniqueCode
    {
        private readonly AppDbContext _context;
        public CheckUniqueCodeRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool CheckCode(string code)
        {
            return _context.Links.Any(l => l.Code.Equals(code));
        }
    }
}
