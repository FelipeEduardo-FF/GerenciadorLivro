using GerenciadorLivro.Application.Results;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorLivro.Application.Command.Books
{
    public class ReturnBook:IRequest<Result>
    {
        public ReturnBook(int bookId, Guid userId)
        {
            BookId = bookId;
            UserId = userId;
        }

        [Required]
        public int BookId { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
