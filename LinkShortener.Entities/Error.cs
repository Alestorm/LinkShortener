using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Entities
{
    public sealed record Error(string Code, string? Message = null)
    {
        public static readonly Error None = new(string.Empty);
    }
}
