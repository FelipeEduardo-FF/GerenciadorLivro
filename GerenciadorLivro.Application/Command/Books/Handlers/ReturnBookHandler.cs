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

    public class ReturnBookHandler : IRequestHandler<ReturnBook,Result>
    {
        private readonly ILoanRepository _repository;
        private readonly IBookRepository _bookRepository;

        public ReturnBookHandler(ILoanRepository repository,IBookRepository bookRepository)
        {
            this._repository = repository;
            this._bookRepository = bookRepository;
        }
        public async Task<Result> Handle(ReturnBook request, CancellationToken cancellationToken)
        {
            var loan = await _repository.GetByBookAndUser(request.BookId, request.UserId);
            if (loan is null)
                return ErrorType.NotFound("Loan not found");

            if (loan.DateReturned is not null)
                return ErrorType.NotFound("Book returned");

            var book = await _bookRepository.GetById(request.BookId);
            
            loan.Devolution();
            await _repository.Update(loan);

            book.MakeAvailable();
            await _bookRepository.Update(book);
            return Result.Ok();
        }
    }
}
