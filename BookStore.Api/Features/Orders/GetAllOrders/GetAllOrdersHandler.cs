using AutoMapper;
using BookStore.Api.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace BookStore.Api.Features.Orders.GetAllOrders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<GetAllOrdersResponse>>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetAllOrdersHandler(BookStoreDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<List<GetAllOrdersResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Orders
                .Select(o => new GetAllOrdersResponse(o.Id,
                o.OrderDate,
                o.TotalAmount
                )).ToListAsync(cancellationToken);

            ;
        }
    }
}