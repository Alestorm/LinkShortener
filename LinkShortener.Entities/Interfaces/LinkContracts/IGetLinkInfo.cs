using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Entities.Interfaces.LinkContracts
{
    public interface IGetLinkInfo
    {
        Task<Response> GetLinkInfo(string shorturl);
    }
}
