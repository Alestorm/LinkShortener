using LinkShortener.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.UseCases.UserUseCases.Interfaces
{
    public interface IGetLinksService
    {
        Task<Response> GetLinks(int idUser);
    }
}
