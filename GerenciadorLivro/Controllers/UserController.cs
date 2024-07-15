using GerenciadorLivro.Application.Query.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            var result = await _mediator.Send(query);

            if(result is null)
                return NotFound();

            return Ok(result);
        }


        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var query = new GetUsers();
            var result = await _mediator.Send(query);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUser request)
        {
            var id = await _mediator.Send(request);
            return CreatedAtAction(nameof(Get), new { id = id }, request);
        }
    }
}
