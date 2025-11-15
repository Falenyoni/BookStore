using BookStore.Api.Domain.Entities;
using BookStore.Api.Infrastructure.Data;
using MediatR;

namespace BookStore.Api.Features.Books.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, CreateBookResponse>
    {
        private readonly BookStoreDbContext _context;

        public CreateBookHandler(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<CreateBookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Price = request.Price,
                PublishedOn = request.PublishedOn
            };

            _context.Books.Add(book);

            await _context.SaveChangesAsync(cancellationToken);

            return new CreateBookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                PublishedOn = book.PublishedOn
            };
        }
    }
}