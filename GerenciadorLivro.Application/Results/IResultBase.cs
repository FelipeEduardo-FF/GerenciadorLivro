using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GerenciadorLivro.Application.Results
{
    public interface IResultBase
    {
        Error Error { get; }
        bool Success { get; }
    }
}
