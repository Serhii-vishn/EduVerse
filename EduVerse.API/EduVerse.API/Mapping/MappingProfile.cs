namespace EduVerse.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GroupEntity, GroupDTO>()
                .ForMember(dest => dest.StudentIds, opt => opt.MapFrom(src => src.Students.Select(s => s.Id).ToList()))
                .ForMember(dest => dest.LessonIds, opt => opt.MapFrom(src => src.Lessons.Select(l => l.Id).ToList()))
                .ForMember(dest => dest.GroupScheduleIds, opt => opt.MapFrom(src => src.GroupSchedule.Select(gs => gs.Id).ToList()))
                .ReverseMap();

            CreateMap<GroupEntity, GroupListDTO>()
                 .ForMember(dest => dest.CuratorFullName, opt => opt.MapFrom(src => $"{src.Curator.FirstName} {src.Curator.LastName}"))
                 .ReverseMap();

            CreateMap<ScheduleEntity, ScheduleDTO>()
                .ReverseMap();

            CreateMap<ScheduleEntity, ScheduleListDTO>()
                .ForMember(dest => dest.LessonName, opt => opt.MapFrom(src => src.Lesson.Name))
                .ForMember(dest => dest.TeacherFullName, opt => opt.MapFrom(src => $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group.GroupName));

            CreateMap<ScheduleEntity, ScheduleLessonDTO>()
                .ForMember(dest => dest.LessonName, opt => opt.MapFrom(src => src.Lesson.Name))
                .ForMember(dest => dest.TeacherFullName, opt => opt.MapFrom(src => $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group.GroupName))
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Group.Students.ToList()))
                .ForMember(dest => dest.Attendances, opt => opt.MapFrom(src => src.Attendances.ToList()))
                .ForMember(dest => dest.Grades, opt => opt.MapFrom(src => src.Grades.ToList()));

            CreateMap<LessonEntity, LessonListDTO>()
                .ReverseMap();

            CreateMap<TeacherEntity, TeacherDTO>()
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups.ToList()))
                .ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src.Lessons.ToList()))
                .ForMember(dest => dest.PictureFileName, opt => opt.MapFrom<TeacherPictureResolver>())
                .ReverseMap();

            CreateMap<TeacherEntity, TeacherListDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.PictureFileName, opt => opt.MapFrom<TeacherListPictureResolver>());

            CreateMap<AddTeacherRequest, TeacherEntity>()
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups.ToList()))
                .ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src.Lessons.ToList()));

            CreateMap<UpdateTeacherRequest, TeacherEntity>()
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups.ToList()))
                .ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src.Lessons.ToList()));

            CreateMap<AddTeacherRequest, UpdateTeacherRequest>()
                .ReverseMap();

            CreateMap<StudentEntity, StudentDTO>()
                .ForMember(dest => dest.PictureFileName, opt => opt.MapFrom<StudentPictureResolver>())
                .ForMember(dest => dest.Parents, opt => opt.MapFrom(src => src.Parents.ToList()))
                .ReverseMap();

            CreateMap<StudentEntity, StudentListDTO>()
                 .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                 .ForMember(dest => dest.PictureFileName, opt => opt.MapFrom<StudentListPictureResolver>());

            CreateMap<StudentEntity, StudentAttedanceDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Attendances, opt => opt.MapFrom(src => src.Attendance.ToList()))
                .ReverseMap();

            CreateMap<StudentEntity, StudentGradesDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Grades, opt => opt.MapFrom(src => src.Grades.ToList()))
                .ReverseMap();

            CreateMap<ParentEntity, ParentListDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.PictureFileName, opt => opt.MapFrom<ParentListPictureResolver>());

            CreateMap<AttendanceEntity, AttedanceDTO>()
                .ReverseMap();

            CreateMap<AttendanceEntity, AttendanceListDTO>()
                .ReverseMap();

            CreateMap<GradeEntity, GradeListDTO>()
                .ReverseMap();

            CreateMap<GradeEntity, GradeDTO>()
                .ReverseMap();
        }
    }
}
