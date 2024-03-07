using LinkShortener.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Entities.Interfaces.LinkContracts
{
    public interface ICreateLink
    {
        Task<Response> CreateLink(Link link);
    }
}
