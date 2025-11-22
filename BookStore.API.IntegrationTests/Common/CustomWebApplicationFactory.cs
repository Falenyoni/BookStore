using BookStore.Api.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BookStore.API.IntegrationTests.Common
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<BookStoreDbContext>));

                if (descriptor == null)
                    services.Remove(descriptor);

                // Add InMemory DbContext for testing
                services.AddDbContext<BookStoreDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));

                // Ensure MemoryCache is available
                services.AddMemoryCache();
            });
        }
    }
}