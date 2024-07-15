using GerenciadorLivro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.DTO.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel(Guid id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }

        public static UserViewModel FromEntity(User user)
        {
            return new UserViewModel(user.Id,user.Nome,user.Email);
        }
    }
}
