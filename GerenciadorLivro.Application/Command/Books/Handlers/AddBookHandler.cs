using GerenciadorLivro.Application.Command.Books;
using GerenciadorLivro.Application.Results;
using GerenciadorLivro.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Command.Books.Handlers
{
    public class AddBookHandler : IRequestHandler<AddBook, Result<int>>
    {
        private readonly IBookRepository _repository;

        public AddBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> Handle(AddBook request, CancellationToken cancellationToken)
        {
            var book = request.ToEntity();
            await _repository.Create(book);
            return book.Id;
        }
    }
}
