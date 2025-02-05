using AutoMapper;
using EntityFrameworkApp.DTO;
using EntityFrameworkApp.Model;

namespace EntityFrameworkApp.Mappers
{
    public class Mapper:Profile
    {
        public Mapper(IMapper mapper)
        {
            CreateMap<Book, BookDto>();
        }
    }
}
