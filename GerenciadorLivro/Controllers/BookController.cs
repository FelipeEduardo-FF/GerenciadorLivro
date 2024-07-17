using GerenciadorLivro.API.Extensions;
using GerenciadorLivro.Application.Command.Books;
using GerenciadorLivro.Application.Query.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BookController:ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response=await _mediator.Send(new GetBookById(id));
            return response.Match(
                success: (value) => Ok(value),
                failure: value => value.ToProblemDetails());
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetBooks());
            return response.Match(
                success: (value) => Ok(value),
                failure: value => value.ToProblemDetails());
        }

        [HttpGet("Available")]
        public async Task<IActionResult> GetAvailable()
        {
            var response = await _mediator.Send(new GetBooksAvailable());
            return response.Match(
                success: (value) => Ok(value),
                failure: value => value.ToProblemDetails());
        }

        [HttpGet("Reserved")]
        public async Task<IActionResult> GetReserved()
        {
            var response = await _mediator.Send(new GetBooksReserved());
            return response.Match(
                success: (value) => Ok(value),
                failure: value => value.ToProblemDetails());
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddBook request)
        {
            var response = await _mediator.Send(request);
            return response.Match(
                success: (value) => Ok(value),
                failure: value => value.ToProblemDetails());
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBook request)
        {
            await _mediator.Send(request);
            return Ok();
        }


        [HttpPost("{bookId}/lean/user/{userId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LeanBook(int bookId,Guid userId)
        {
            var request = new LeanBook(bookId, userId);
            var response = await _mediator.Send(request);

            return response.Match(
                        success: (value) => Ok(value),
                        failure: value => value.ToProblemDetails());

        }        
        [HttpPost("{bookId}/return/user/{userId}")]
        public async Task<IActionResult> ReturnBook(int bookId,Guid userId)
        {
            var request = new ReturnBook(bookId, userId);
            var result=await _mediator.Send(request);
            return result.Match(
                    success: ()=>NoContent(),
                    failure: value => value.ToProblemDetails());
        }
    }
}
