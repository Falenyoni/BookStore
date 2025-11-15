using BookStore.Api.Features.Books.CreateBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<CreateBookResponse>> CreateBook([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}