using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Domain.Model
{
    public class Loan
    {
        public Loan(Guid userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
            DateLoan = DateTime.Now;
            DateLoan = DateTime.Now.AddDays(7);
            DateReturned = null;
        }

        public int Id { get; private set; }
        public Guid UserId { get; private set; }
        public int BookId { get; private set; }
        public DateTime DateLoan { get; private set; }
        public DateTime DateDevolution { get; private set; }
        public DateTime? DateReturned { get; private set; }
        public User? User { get; set; }
        public Book? Book { get; set; }

        public void Devolution()
        {
            DateReturned= DateTime.Now;
        }
    }
}
