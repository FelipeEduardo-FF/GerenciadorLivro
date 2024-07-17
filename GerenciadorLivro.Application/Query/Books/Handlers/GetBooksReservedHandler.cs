using GerenciadorLivro.Application.DTO.ViewModel;
using GerenciadorLivro.Application.Results;
using GerenciadorLivro.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Query.Books.Handlers
{
    internal class GetBooksReservedHandler : IRequestHandler<GetBooksReserved, Result<List<BookViewModel>>>
    {
        private readonly IBookRepository _repository;

        public GetBooksReservedHandler(IBookRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Result<List<BookViewModel>>> Handle(GetBooksReserved request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetReserved();

            var booksview = books.Select(x => BookViewModel.FromEntity(x)).ToList();

            return booksview;
        }
    }
}
