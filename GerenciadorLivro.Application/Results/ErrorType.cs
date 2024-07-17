using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Results
{
    public static class ErrorType
    {

        public static Error NotFound(string message)
        {
            return new Error(404, message);
        }

        public static Error BadRequest(string message)
        {
            return new Error(400, message);
        }
    }
}
