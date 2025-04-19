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
            CreateMap<Users, UserLoginDto>();
            CreateMap<UserLoginDto, Users>();
            CreateMap<CartsDto, Carts>();
            CreateMap<Carts, CartsDto>();
            CreateMap<Enrollments, EnrollmentDto>();
            CreateMap<EnrollmentDto, Enrollments>();
            CreateMap<ReviewsDto, Reviews>();
            CreateMap<Reviews, ReviewsDto>();
            CreateMap<Users, TeacherDto>();
            CreateMap<Courses, CoursesDto>();
            CreateMap<CoursesDto, Courses>();
        }
    }
}
