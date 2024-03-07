using LinkShortener.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Entities.Interfaces.UserContracts
{
    public interface IGetUserList
    {
        Task<Response> GetUsers();
    }
}
