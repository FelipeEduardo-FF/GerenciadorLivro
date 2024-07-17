using GerenciadorLivro.Application.Results;
using GerenciadorLivro.Domain.Repositories;
using MediatR;

namespace GerenciadorLivro.Application.Command.Books.Handlers
{
    public class UpdateBookHandler : IRequestHandler<UpdateBook, Result>
    {
        private readonly IBookRepository _repository;

        public UpdateBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result> Handle(UpdateBook request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetById(request.Id);

            books.Update(request.Title, request.Author, request.ISBN, request.YearPublication);

            await _repository.Update(books);

            return Result.Ok();
        }
    }
}
