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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task Create(User model)
        {
            _context.Users.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _context.Users.SingleOrDefaultAsync(x=>x.Id==id);
        }
    }
}
