namespace EduVerse.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GroupEntity, GroupDTO>()
                .ForMember(dest => dest.StudentIds, opt => opt.MapFrom(src => src.Students.Select(s => s.Id)))
                .ForMember(dest => dest.LessonIds, opt => opt.MapFrom(src => src.Lessons.Select(l => l.Id)))
                .ForMember(dest => dest.GroupScheduleIds, opt => opt.MapFrom(src => src.GroupSchedule.Select(gs => gs.Id)));

            CreateMap<ScheduleEntity, ScheduleDTO>()
                .ReverseMap();

            CreateMap<ScheduleEntity, ScheduleListDTO>()
                .ForMember(dest => dest.LessonName, opt => opt.MapFrom(src => src.Lesson.Name))
                .ForMember(dest => dest.TeacherFullName, opt => opt.MapFrom(src => $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group.GroupName));
        }
    }
}
