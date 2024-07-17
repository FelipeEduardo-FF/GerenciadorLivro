using GerenciadorLivro.Application.DTO.ViewModel;
using GerenciadorLivro.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Query.Books
{
    public class GetBookById:IRequest<Result<BookViewModel>>
    {
        public GetBookById(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
