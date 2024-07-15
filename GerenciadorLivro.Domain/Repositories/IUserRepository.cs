using GerenciadorLivro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Domain.Repositories
{
    public interface IUserRepository
    {
        Task Create(User model);
        Task<IList<User>> Get();
        Task<User> GetById(Guid id);
    }
}
