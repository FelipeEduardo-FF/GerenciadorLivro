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
    public class GetBookByIdHandler : IRequestHandler<GetBookById, Result<BookViewModel>>
    {
        private readonly IBookRepository _repository;

        public GetBookByIdHandler(IBookRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Result<BookViewModel>> Handle(GetBookById request, CancellationToken cancellationToken)
        {
           var book= await _repository.GetById(request.Id);

            return BookViewModel.FromEntity(book);
        }
    }
}
