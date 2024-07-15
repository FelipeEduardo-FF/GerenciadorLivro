using GerenciadorLivro.Application.DTO.ViewModel;
using GerenciadorLivro.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Query.Users.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsers, List<UserViewModel>>
    {
        private readonly IUserRepository _repository;

        public GetUsersHandler(IUserRepository repository)
        {
            this._repository = repository;
        }
        public async Task<List<UserViewModel>> Handle(GetUsers request, CancellationToken cancellationToken)
        {
            var users = await _repository.Get();
            List<UserViewModel> userViewModels = users.Select(x=>UserViewModel.FromEntity(x)).ToList();

            return userViewModels;
        }
    }
}
