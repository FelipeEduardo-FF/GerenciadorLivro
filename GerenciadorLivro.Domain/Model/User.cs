using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Domain.Model
{
    public class User
    {
        public User( string nome, string email)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }

    }
}
