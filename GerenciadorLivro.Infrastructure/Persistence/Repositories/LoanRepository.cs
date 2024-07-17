using GerenciadorLivro.Domain.Model;
using GerenciadorLivro.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivro.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _context;
        public LoanRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task Create(Loan model)
        {
            _context.Loans.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Loan>> Get()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<Loan?> GetByBookAndUser(int bookId, Guid userId)
        {
           return await _context.Loans.OrderByDescending(x=>x.Id).FirstOrDefaultAsync(x => x.BookId==bookId && x.UserId== userId);
        }

        public async Task<Loan?> GetById(int id)
        {
            return await _context.Loans.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task Update(Loan model)
        {
            _context.Loans.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
