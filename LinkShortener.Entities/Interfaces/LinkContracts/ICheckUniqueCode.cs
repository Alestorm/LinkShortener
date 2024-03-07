using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Entities.Interfaces.LinkContracts
{
    public interface ICheckUniqueCode
    {
        bool CheckCode(string code);
    }
}
