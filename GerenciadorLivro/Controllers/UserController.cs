using Azure;
using GerenciadorLivro.API.Extensions;
using GerenciadorLivro.Application.Command.Users;
using GerenciadorLivro.Application.Query.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetUserById(id);
            var response = await _mediator.Send(query);

            return response.Match(
                success: (value) => Ok(value),
                failure: value => value.ToProblemDetails());
        }


        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var query = new GetUsers();
            var response = await _mediator.Send(query);

            return response.Match(
                success: (value) => Ok(value),
                failure: value => value.ToProblemDetails());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUser request)
        {
            var response = await _mediator.Send(request);
            return response.Match(
                 success: (value) => CreatedAtAction(nameof(Get), new { id = value }, request) ,
                 failure: value => value.ToProblemDetails());
        }
    }
}
