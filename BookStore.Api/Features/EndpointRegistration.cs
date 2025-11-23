using BookStore.Api.Features.Books.CreateBook;
using BookStore.Api.Features.Books.GetAllBooks;
using BookStore.Api.Features.Books.GetBookById;
using BookStore.Api.Features.Orders.GetAllOrders;
using BookStore.Api.Features.Orders.GetOrderById;
using BookStore.Api.Features.Orders.PlaceOrder;

namespace BookStore.Api.Features
{
    public static class EndpointRegistration
    {
        public static void MapAllEndPoints(this WebApplication app)
        {
            //Books
            app.MapCreateBookEndpoints();
            app.MapGetBookByIdEndpoints();
            app.MapGetAllBooksEndpoints();

            // Orders
            app.MapPlaceOrderEndpoints();
            app.MapGetOrderByIdEndpoints();
            app.MapGetAllOrdersEndpoints();
        }
    }
}