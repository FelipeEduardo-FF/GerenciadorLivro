using GerenciadorLivro.Application.Command.Users;
using GerenciadorLivro.Application.Results;
using GerenciadorLivro.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Command.Users.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUser, Result<Guid>>
    {
        private readonly IUserRepository _repository;

        public AddUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<Guid>> Handle(AddUser request, CancellationToken cancellationToken)
        {
            var user = request.ToEntity();
            await _repository.Create(user);

            return user.Id;
        }
    }
}
