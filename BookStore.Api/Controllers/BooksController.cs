using BookStore.Api.Features.Books.CreateBook;
using BookStore.Api.Features.Books.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetBookByIdResponse>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetBookByIdQuery(id));

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CreateBookResponse>> CreateBook([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}