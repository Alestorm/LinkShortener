using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Entities
{
    public static class ResponseFactory
    {
        public static Response CreateResponse(int status, string message, object? data = null, Error? error = null)
        {
            return new Response
            {
                Status = status,
                Message = message,
                Data = data,
                Error = error
            };
        }
    }
}
