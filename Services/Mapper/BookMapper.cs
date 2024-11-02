using AutoMapper;
using Domain.Entities;
using Shared;

namespace Services.Mapper
{
    public class BookMapper
    {
        private readonly IMapper mapperToDTO;
        private readonly IMapper mapperToEntity;

        public BookMapper()
        {
            mapperToDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDTO>()
                    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null));
            }).CreateMapper();
            mapperToEntity = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>()).CreateMapper();
        }

        public BookDTO ToDTO(Book book)
        {
            return mapperToDTO.Map<BookDTO>(book);
        }

        public Book ToEntity(BookDTO bookDTO)
        {
            return mapperToEntity.Map<Book>(bookDTO);
        }

        public ICollection<BookDTO> ToListDTO(ICollection<Book> books)
        {
            return mapperToDTO.Map<ICollection<BookDTO>>(books);
        }

        public ICollection<Book> ToListEntity(ICollection<BookDTO> bookDTOs)
        {
            return mapperToEntity.Map<ICollection<Book>>(bookDTOs);
        }
    }
}
