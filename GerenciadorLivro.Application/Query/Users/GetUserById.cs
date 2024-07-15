using GerenciadorLivro.Application.DTO.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Query.Users
{
    public class GetUserById:IRequest<UserViewModel>
    {
        public GetUserById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
