namespace EduVerse.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IGroupRepository groupRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
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

        public async Task<int> AddAsync(StudentDTO student)
        {
            ValidateStudent(student);
            await _groupRepository.GetAsync(student.Id);

            var data = await _studentRepository.GetAsync(student.LastName, student.FirstName, student.DateOfBirth);
            if (data != null)
            {
                throw new ArgumentException($"Student already exists");
            }

            student.Id = default;

            return await _studentRepository.AddAsync(_mapper.Map<StudentEntity>(student));
        }

        public async Task<int> DeleteAsync(int id)
        {
            await GetAsync(id);

            return await _studentRepository.DeleteAsync(id);
        }

        private void ValidateStudent(StudentDTO student)
        {
            if (student is null)
            {
                throw new ArgumentNullException(nameof(student), "Student is empty");
            }

            if (string.IsNullOrEmpty(student.FirstName) || student.FirstName.Length > 55)
            {
                throw new ArgumentException("FirstName is required and should be maximum 55 characters long", nameof(student.FirstName));
            }

            if (string.IsNullOrEmpty(student.LastName) || student.LastName.Length > 55)
            {
                throw new ArgumentException("LastName is required and should be maximum 55 characters long", nameof(student.FirstName));
            }

            if (student.DateOfBirth < DateOnly.Parse("1950-01-01"))
            {
                throw new ArgumentException("Invalid date of bith", nameof(student.DateOfBirth));
            }

            student.Gender = student.Gender.ToUpper();

            if (string.IsNullOrEmpty(student.Gender) || student.Gender.Length > 7)
            {
                throw new ArgumentException("Gender is required and should be maximum 7 characters long", nameof(student.Gender));
            }
            else if (!Enum.TryParse(typeof(Genders), student.Gender, out var gender) || !Enum.IsDefined(typeof(Genders), gender))
            {
                throw new ArgumentException("Invalid gender", nameof(student.Gender));
            }

            if (string.IsNullOrWhiteSpace(student.PhoneNumber))
            {
                throw new ArgumentNullException(nameof(student.PhoneNumber), "Phone number is empty");
            }
            else
            {
                student.PhoneNumber = student.PhoneNumber.Trim();

                const string ukrainianPhoneNumberPattern = @"^380\d{9}$";

                if (!Regex.IsMatch(student.PhoneNumber, ukrainianPhoneNumberPattern))
                {
                    throw new ArgumentException(nameof(student.PhoneNumber), "Phone number is invalid");
                }
            }

            if (string.IsNullOrWhiteSpace(student.Email) || student.Email.Length > 30)
            {
                throw new ArgumentException("Email is required and should be maximum 30 characters long", nameof(student.Email));
            }
        }
    }
}
