using AutoMapper;
using BookStore.Api.Domain.Entities;
using BookStore.Api.Features.Books;
using BookStore.Api.Features.Books.GetBookById;
using BookStore.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Shouldly;

namespace BookStore.API.UnitTests.Features.Books.GetBookById
{
    public class GetBookByIdHandlerTests
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookByIdHandlerTests()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            _context = new BookStoreDbContext(options);

            var config = new MapperConfiguration(cfg =>
            cfg.AddProfile(new BookMappingProfile()));

            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Handle_ShouldReturnGetBookByIdResponse_WhenBookExist_WithInMemoryCache()
        {
            // This Test uses a real memory cache

            // Arrange
            var book = new Book { Title = "Book", Author = "Author", Price = 19.99m, PublishedOn = DateTime.Today };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var handler = new GetBookByIdHandler(_context, _mapper, memoryCache); // added  to cache

            // Act
            var result = await handler.Handle(new GetBookByIdQuery(book.Id), CancellationToken.None);

            // Assert using xUnit
            Assert.NotNull(result);
            Assert.Equal(book.Title, result.Title);
            Assert.Equal(book.Author, result.Author);
            Assert.Equal(book.Price, result.Price);
            Assert.Equal(book.PublishedOn, result.PublishedOn);

            // Assert using Shouldly
            result.ShouldNotBeNull();
            book.Title.ShouldBe(result.Title);
            book.Author.ShouldBe(result.Author);
            book.Price.ShouldBe(result.Price);
            book.PublishedOn.ShouldBe(result.PublishedOn);
        }

        [Fact]
        public async Task Handle_ShouldReturnGetBookByIdResponse_WhenBookExist_WithMockedCache()
        {
            //This Test uses a mock version of Memory cache

            // Arrange
            var book = new Book { Title = "Book", Author = "Author", Price = 19.99m, PublishedOn = DateTime.Today };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            var cacheMock = new Mock<IMemoryCache>();

            // Mock TryGetValue
            cacheMock
                .Setup(x => x.TryGetValue(It.IsAny<object>(), out It.Ref<object>.IsAny))
                .Returns(false);

            // Mock Set to Return  a MemoryCacheEntry (can be null for test)
            cacheMock
                .Setup(x => x.CreateEntry(It.IsAny<object>()))
                .Returns(Mock.Of<ICacheEntry>());

            var handler = new GetBookByIdHandler(_context, _mapper, cacheMock.Object);

            // Act
            var result = await handler.Handle(new GetBookByIdQuery(book.Id), CancellationToken.None);

            // Assert using xUnit
            Assert.NotNull(result);
            Assert.Equal(book.Title, result.Title);
            Assert.Equal(book.Author, result.Author);
            Assert.Equal(book.Price, result.Price);
            Assert.Equal(book.PublishedOn, result.PublishedOn);

            // Assert using Shouldly
            result.ShouldNotBeNull();
            book.Title.ShouldBe(result.Title);
            book.Author.ShouldBe(result.Author);
            book.Price.ShouldBe(result.Price);
            book.PublishedOn.ShouldBe(result.PublishedOn);
        }
    }
}