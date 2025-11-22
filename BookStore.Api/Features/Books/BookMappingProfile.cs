using AutoMapper;
using BookStore.Api.Domain.Entities;
using BookStore.Api.Features.Books.GetAllBooks;
using BookStore.Api.Features.Books.GetBookById;

namespace BookStore.Api.Features.Books
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, GetBookByIdResponse>();

            CreateMap<List<Book>, GetAllBooksResponse>()
                .ForMember(
                dest => dest.Books,
                opt => opt.MapFrom(src => src));
        }
    }
}