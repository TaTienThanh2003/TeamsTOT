using AutoMapper;
using backTOT.Dto;
using backTOT.Entitys;

namespace backTOT.Halper
{
    public class MappingProFiles : Profile
    {
        public MappingProFiles() {
            CreateMap<Users, UserDto>();
            CreateMap<UserDto, Users>();
            CreateMap<CartsDto, Carts>();
            CreateMap<Carts, CartsDto>();
            CreateMap<Courses, CoursesDto>();
            CreateMap<CoursesDto, Courses>();
        }
    }
}
