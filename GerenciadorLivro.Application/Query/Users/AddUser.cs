using GerenciadorLivro.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Query.Users
{
    public class AddUser:IRequest<Guid>
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;

        public User ToEntity()
        {
            return new User(Nome, Email);
        }
    }
}
