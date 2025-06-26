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
            CreateMap<Courses, CoursesActionDto>();
            CreateMap<CoursesActionDto, Courses>();
            CreateMap<Enrollments, EnrollmentDtoResponse>();
            CreateMap<CommentsDto, Comments>();
            CreateMap<Comments, CommentsDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.users)) ;
            CreateMap<CommentDto, Comments>();
            CreateMap<Comments, CommentDto>();
            CreateMap<Users, UsersCommentsDto>()
                 .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.FullName)) 
                 .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image)) ;
            CreateMap<UsersCommentsDto, Users>();
            CreateMap<Lesson_notes, Lesson_notesDto>();
            CreateMap<Lesson_notesDto, Lesson_notes>();
            CreateMap<Lessons, LessonsDto>();
            CreateMap<LessonsDto, Lessons>();
            CreateMap<Sections, SectionsDto>();
            CreateMap<SectionsDto, Sections>();
            CreateMap<UserLessonCreateDto, UserLesson>();
            CreateMap<UserLesson, UserLessonCreateDto>();
            CreateMap<UpdateUserTopicCompleteDto, UserTopics>();
            CreateMap<UserTopics, UpdateUserTopicCompleteDto>();
            CreateMap<AddUserTopicDto, UserTopics>();
            CreateMap<UserTopics, AddUserTopicDto>();
        }
    }
}
