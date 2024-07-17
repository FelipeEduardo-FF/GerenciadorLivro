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
    public class GetUsersHandler : IRequestHandler<GetUsers, Result<List<UserViewModel>>>
    {
        private readonly IUserRepository _repository;

        public GetUsersHandler(IUserRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Result<List<UserViewModel>>> Handle(GetUsers request, CancellationToken cancellationToken)
        {
            var users = await _repository.Get();
            List<UserViewModel> userViewModels = users.Select(x=>UserViewModel.FromEntity(x)).ToList();

            return userViewModels;
        }
    }
}
