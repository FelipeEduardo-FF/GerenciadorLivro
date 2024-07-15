using GerenciadorLivro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Domain.Repositories
{
    public interface IBookRepository
    {
        Task Create(Book model);
        Task Update(Book model);
        Task<IList<Book>> Get();
        Task<IList<Book>> GetReserved();
        Task<IList<Book>> GetAvailable();
        Task<Book> GetById(int id);
        Task Delete(Book model);
    }
}
