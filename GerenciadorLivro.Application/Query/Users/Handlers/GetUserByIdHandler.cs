using GerenciadorLivro.Application.DTO.ViewModel;
using GerenciadorLivro.Application.Results;
using GerenciadorLivro.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Query.Users.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserById, Result<UserViewModel>>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdHandler(IUserRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Result<UserViewModel>> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.Id);

            return UserViewModel.FromEntity(user);
        }
    }
}
