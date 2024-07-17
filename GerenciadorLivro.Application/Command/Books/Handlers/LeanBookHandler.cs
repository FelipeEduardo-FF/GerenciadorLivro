using GerenciadorLivro.Application.Results;
using GerenciadorLivro.Domain.Model;
using GerenciadorLivro.Domain.Repositories;
using MediatR;

namespace GerenciadorLivro.Application.Command.Books.Handlers
{
    public class LeanBookHandler : IRequestHandler<LeanBook, Result<int>>
    {
        private readonly ILoanRepository _repository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public LeanBookHandler(ILoanRepository repository,IBookRepository  bookRepository,IUserRepository userRepository)
        {
            this._repository = repository;
            this._bookRepository = bookRepository;
            this._userRepository = userRepository;
        }
        public async Task<Result<int>> Handle(LeanBook request, CancellationToken cancellationToken)
        {
            var book=await _bookRepository.GetById(request.BookId);
            if (book is null)
                return ErrorType.NotFound("book not found");

            if (book.Status==StatusBook.reserved)
                return ErrorType.BadRequest("book reserved");

            var user = await _userRepository.GetById(request.UserId);
            if (user is null)
                return ErrorType.NotFound("User not found");

            var loanBook = request.ToEntity();
            await _repository.Create(loanBook);

            book.Reserve();
            await _bookRepository.Update(book);

            return loanBook.Id;
        }
    }
}
