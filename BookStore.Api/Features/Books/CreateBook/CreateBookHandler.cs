using BookStore.Api.Domain.Entities;
using BookStore.Api.Infrastructure.Data;
using MediatR;

namespace BookStore.Api.Features.Books.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, CreateBookResponse>
    {
        private readonly BookStoreDbContext _context;
        //private readonly ILogger<CreateBookHandler> _logger;

        public CreateBookHandler(BookStoreDbContext context)
        {
            _context = context;
            //_logger = logger;
        }

        public async Task<CreateBookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            //_logger.LogInformation("Creating book: {Title}", request.Title);

            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Price = request.Price,
                PublishedOn = request.PublishedOn
            };

            _context.Books.Add(book);

            await _context.SaveChangesAsync(cancellationToken);

            //_logger.LogInformation("Book created with ID: {Id}", book.Id);
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