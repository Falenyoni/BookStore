using BookStore.Api.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookStore.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddDbContext<BookStoreDbContext>(options =>
            options.UseInMemoryDatabase("BookStoreDb"));
            services.AddAutoMapper(typeof(Program));
            return services;
        }
    }
}