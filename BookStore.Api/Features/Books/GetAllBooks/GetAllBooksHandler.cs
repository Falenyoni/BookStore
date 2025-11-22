using AutoMapper;
using BookStore.Api.Features.Books.GetBookById;
using BookStore.Api.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace BookStore.Api.Features.Books.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, GetAllBooksResponse?>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetAllBooksHandler(BookStoreDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<GetAllBooksResponse?> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.Books.ToListAsync();

            return books is null ? null : _mapper.Map<GetAllBooksResponse>(books);
        }
    }
}