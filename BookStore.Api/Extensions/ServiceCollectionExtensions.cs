using BookStore.Api.Infrastructure.Behaviors;
using BookStore.Api.Infrastructure.Data;
using FluentValidation;
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
            services.AddValidatorsFromAssemblyContaining<Program>();
            services.AddAutoMapper(typeof(Program));
            services.AddMemoryCache();
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidatorBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>),
            //   typeof(LoggingBehavior<,>));
            return services;
        }
    }
}