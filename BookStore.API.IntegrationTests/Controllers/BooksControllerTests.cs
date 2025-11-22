using BookStore.Api.Features.Books.CreateBook;
using BookStore.Api.Features.Books.GetBookById;
using BookStore.API.IntegrationTests.Common;
using Shouldly;
using System.Net.Http.Json;

namespace BookStore.API.IntegrationTests.Controllers
{
    public class BooksControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public BooksControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostCreateBook_ShouldReturnBookResponse()
        {
            // Arrage
            var command = new CreateBookCommand("Integration Test", "Author", 19.99m, DateTime.Today);

            // Act
            var response = await _client.PostAsJsonAsync("/api/books", command);

            var result = await response.Content.ReadFromJsonAsync<CreateBookResponse>();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(result);
            Assert.Equal(command.Title, result.Title);
            Assert.Equal(command.Author, result.Author);
            Assert.Equal(command.Price, result.Price);
            Assert.Equal(command.PublishedOn, result.PublishedOn);

            // Assert using Shouldly
            result.ShouldNotBeNull();
            command.Title.ShouldBe(result.Title);
            command.Author.ShouldBe(result.Author);
            command.Price.ShouldBe(result.Price);
            command.PublishedOn.ShouldBe(result.PublishedOn);
        }

        [Fact]
        public async Task GetBookById_ShouldReturnGetBookByIdResponse()
        {
            // Arrange
            var command = new CreateBookCommand("GetBookById Test", "Author", 15.99m, DateTime.Today);

            var response = await _client.PostAsJsonAsync("/api/books", command);

            var createdBook = await response.Content.ReadFromJsonAsync<CreateBookResponse>();

            // Act
            var getResponse = await _client.GetAsync($"/api/books/{createdBook.Id}");

            var getBookByIdResponse = await getResponse.Content.ReadFromJsonAsync<GetBookByIdResponse>();

            // Assert
            getResponse.EnsureSuccessStatusCode();
            Assert.NotNull(getBookByIdResponse);
            Assert.Equal(command.Title, getBookByIdResponse.Title);
            Assert.Equal(command.Author, getBookByIdResponse.Author);
            Assert.Equal(command.Price, getBookByIdResponse.Price);
            Assert.Equal(command.PublishedOn, getBookByIdResponse.PublishedOn);

            // Assert using Shouldly
            getBookByIdResponse.ShouldNotBeNull();
            command.Title.ShouldBe(getBookByIdResponse.Title);
            command.Author.ShouldBe(getBookByIdResponse.Author);
            command.Price.ShouldBe(getBookByIdResponse.Price);
            command.PublishedOn.ShouldBe(getBookByIdResponse.PublishedOn);
        }
    }
}