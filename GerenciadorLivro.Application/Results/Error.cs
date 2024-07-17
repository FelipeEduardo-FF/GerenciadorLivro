using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Results
{
    public sealed record Error(int Code, string? Message = null);
}
