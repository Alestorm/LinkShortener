using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Entities
{
    public class Response
    {
        public int Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
        public Error? Error { get; set; }
    }
}
