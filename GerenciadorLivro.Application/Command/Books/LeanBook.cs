using GerenciadorLivro.Application.Results;
using GerenciadorLivro.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Command.Books
{
    public class LeanBook:IRequest<Result<int>>
    {
        public LeanBook(int bookId, Guid userId)
        {
            BookId = bookId;
            UserId = userId;
        }

        [Required]
        public int BookId { get; set; }
        [Required]
        public Guid UserId { get; set; }

        public Loan ToEntity()
        {
            return new Loan(UserId, BookId);
        }
    }
}
