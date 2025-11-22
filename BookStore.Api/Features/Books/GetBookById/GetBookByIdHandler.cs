using AutoMapper;
using BookStore.Api.Domain.Entities;
using BookStore.Api.Features.Books.CreateBook;
using BookStore.Api.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace BookStore.Api.Features.Books.GetBookById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, GetBookByIdResponse?>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetBookByIdHandler(BookStoreDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        // Without Cache
        //public async Task<GetBookByIdResponse?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        //{
        //    var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        //    return book is null ? null : _mapper.Map<GetBookByIdResponse>(book);
        //}

        // With Cache
        public async Task<GetBookByIdResponse?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = $"Book_{request.Id}";
            if (_cache.TryGetValue(cacheKey, out GetBookByIdResponse cachedBook))
            {
                return cachedBook;
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (book is null) return null;

            var getBookByIdResponse = _mapper.Map<GetBookByIdResponse>(book);

            _cache.Set(cacheKey, getBookByIdResponse, TimeSpan.FromMinutes(5));

            return getBookByIdResponse;
        }
    }
}