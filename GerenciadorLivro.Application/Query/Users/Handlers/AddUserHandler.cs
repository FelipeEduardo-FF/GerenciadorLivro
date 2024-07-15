using GerenciadorLivro.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Query.Users.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUser, Guid>
    {
        private readonly IUserRepository _repository;

        public AddUserHandler(IUserRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Guid> Handle(AddUser request, CancellationToken cancellationToken)
        {
            var user = request.ToEntity();
            await _repository.Create(user);

            return user.Id;
        }
    }
}
