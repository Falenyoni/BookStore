using BookStore.Api.Features.Books.CreateBook;
using BookStore.Api.Features.Books.GetBookById;
using BookStore.Api.Features.Orders.PlaceOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<PlaceOrderResponse>> PlaceOrder([FromBody] PlaceOrderCommand command)
        {
            var result = await _mediator.Send(command);
            // Return 201 Created with a link to the resource

            return CreatedAtAction(nameof(GetOrderById), new { id = result.OrderId }, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PlaceOrderResponse>> GetOrderById(Guid id, [FromServices] BookStore.Api.Infrastructure.Data.BookStoreDbContext db)
        {
            var order = await db.Orders.FindAsync(id);

            if (order is null)
                return NotFound();

            return Ok(new PlaceOrderResponse(order.Id, order.OrderDate, order.TotalAmount));
        }
    }
}