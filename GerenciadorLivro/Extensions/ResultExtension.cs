
using GerenciadorLivro.Application.Results;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro.API.Extensions
{
    public static class ResultExtension
    {
        public static IActionResult ToProblemDetails(this Error result)
        {

            var problemDetails = new ProblemDetails
            {
                Detail = result.Message,
                Status = result.Code
            };

            return new ObjectResult(problemDetails);
        }
    }
}
