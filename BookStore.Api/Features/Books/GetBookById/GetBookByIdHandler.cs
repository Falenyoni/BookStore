using AutoMapper;
using BookStore.Api.Domain.Entities;
using BookStore.Api.Features.Books.CreateBook;
using BookStore.Api.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Features.Books.GetBookById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, GetBookByIdResponse?>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookByIdHandler(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetBookByIdResponse?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            return book is null ? null : _mapper.Map<GetBookByIdResponse>(book);
        }
    }
}