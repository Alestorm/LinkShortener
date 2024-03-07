using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Entities.Interfaces.UserContracts
{
    public interface IGetLinks
    {
        Task<Response> GetLinks(int idUser);
    }
}
