using AutoMapper;
using BookStore.Api.Domain.Entities;
using BookStore.Api.Features.Books.GetBookById;

namespace BookStore.Api.Features.Books
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, GetBookByIdResponse>();
        }
    }
}