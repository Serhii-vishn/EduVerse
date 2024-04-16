namespace EduVerse.API.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<TeacherDTO> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid teacher id");
            }

            var data = await _teacherRepository.GetAsync(id);

            if (data is null)
            {
                throw new NotFoundException($"Teacher with id = {id} does not exist");
            }

            return _mapper.Map<TeacherDTO>(data);
        }

        public async Task<IList<TeacherListDTO>> ListAsync()
        {
            var data = await _teacherRepository.ListAsync();
            return _mapper.Map<IList<TeacherListDTO>>(data);
        }

        public Task<int> UpdateAsync(TeacherDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
