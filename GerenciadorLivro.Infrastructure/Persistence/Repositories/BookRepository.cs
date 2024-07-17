using GerenciadorLivro.Domain.Model;
using GerenciadorLivro.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task Create(Book model)
        {
             _context.Books.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Book model)
        {
            model.Delete();
            _context.Books.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Book>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<IList<Book>> GetAvailable()
        {
            return await _context.Books.Where(bo=>bo.Status==StatusBook.available).ToListAsync();
        }

        public async Task<Book?> GetById(int id)
        {
            return await _context.Books.SingleOrDefaultAsync(bo=>bo.Id==id && bo.Status!=StatusBook.deleted);
        }

        public async Task<IList<Book>> GetReserved()
        {
            return await _context.Books.Where(bo => bo.Status == StatusBook.reserved).ToListAsync();
        }

        public async Task Update(Book model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
