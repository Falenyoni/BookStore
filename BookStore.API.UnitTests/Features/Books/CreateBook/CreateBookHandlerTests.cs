using BookStore.Api.Features.Books.CreateBook;
using BookStore.Api.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace BookStore.API.UnitTests.Features.Books.CreateBook
{
    public class CreateBookHandlerTests
    {
        private readonly BookStoreDbContext _context;
        private readonly Mock<ILogger<CreateBookHandler>> _loggerMock;

        public CreateBookHandlerTests()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new BookStoreDbContext(options);
            _loggerMock = new Mock<ILogger<CreateBookHandler>>();
        }

        [Fact]
        public async Task Handle_ShouldCreateBookSuccessfully()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();

            var handler = new CreateBookHandler(_context, mediatorMock.Object);

            var command = new CreateBookCommand("Test Book", "Author", 19.99m, DateTime.Today);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Book", result.Title);
            Assert.Equal("Author", result.Author);
            Assert.Equal(19.99m, result.Price);
            Assert.Equal(DateTime.Today, result.PublishedOn);
            Assert.Single(_context.Books);  // Book is saved in DbContext

            result.ShouldNotBeNull();
        }
    }
}