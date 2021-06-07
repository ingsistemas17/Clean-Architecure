

using AutoMapper;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Entity;

namespace Web.Api.Profiles
{
    public class LibroProfile: Profile
    {
        public LibroProfile()
        {
            CreateMap<Libro, LibroRequest>().ReverseMap(); //Map from Developer Object to DeveloperDTO Object
            CreateMap<Autor, AutorRequest>().ReverseMap();
            CreateMap<Editorial, EditorialRequest>().ReverseMap();
        }
    }
}
