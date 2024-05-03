namespace EduVerse.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentDTO> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid student id");
            }

            var data = await _studentRepository.GetAllAsync(id);

            if (data is null)
            {
                throw new NotFoundException($"Student with id = {id} does not exist");
            }

            return _mapper.Map<StudentDTO>(data);
        }

        public async Task<StudentAttedanceDTO> GetAttedanseAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid student id");
            }

            var data = await _studentRepository.GetAllAsync(id);
            return _mapper.Map<StudentAttedanceDTO>(data);
        }

        public async Task<StudentGradesDTO> GetGradesAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid student id");
            }

            var data = await _studentRepository.GetAllAsync(id);
            return _mapper.Map<StudentGradesDTO>(data);
        }

        public async Task<IList<StudentListDTO>> ListAsync()
        {
            var studentsList = await _studentRepository.ListAsync();

            return _mapper.Map<IList<StudentListDTO>>(studentsList);
        }

        public Task<int> UpdateAsync(StudentDTO student)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddAsync(StudentDTO student)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
