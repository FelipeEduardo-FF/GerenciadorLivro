using GerenciadorLivro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Domain.Repositories
{
    public interface ILoanRepository
    {
        Task Create(Loan model);
        Task Update(Loan model);
        Task<Loan> GetById(int id);
        Task<Loan> GetByBookAndUser(int bookId, Guid userId);
        Task<List<Loan>> GetExpired();
    }
}
