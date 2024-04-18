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

            var data = await _teacherRepository.GetAllAsync(id);

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

        public async Task<int> UpdateAsync(TeacherDTO teacher)
        {
            ValidateTeacher(teacher);

            await GetAsync(teacher.Id);

            return await _teacherRepository.UpdateAsync(_mapper.Map<TeacherEntity>(teacher));
        }

        private void ValidateTeacher(TeacherDTO teacher)
        {
            if (teacher is null)
            {
                throw new ArgumentNullException(nameof(teacher), "Teacher is empty");
            }

            if (string.IsNullOrEmpty(teacher.FirstName) || teacher.FirstName.Length > 55)
            {
                throw new ArgumentException("FirstName is required and should be maximum 55 characters long", nameof(teacher.FirstName));
            }

            if (string.IsNullOrEmpty(teacher.LastName) || teacher.LastName.Length > 55)
            {
                throw new ArgumentException("LastName is required and should be maximum 55 characters long", nameof(teacher.FirstName));
            }

            if (teacher.DateOfBirth < DateOnly.Parse("1950-01-01"))
            {
                throw new ArgumentException("Invalid date of bith", nameof(teacher.DateOfBirth));
            }

            teacher.Gender = teacher.Gender.ToUpper();

            if (string.IsNullOrEmpty(teacher.Gender) || teacher.Gender.Length > 7)
            {
                throw new ArgumentException("Gender is required and should be maximum 7 characters long", nameof(teacher.Gender));
            }
            else if (!Enum.TryParse(typeof(Genders), teacher.Gender, out var gender) || !Enum.IsDefined(typeof(Genders), gender))
            {
                throw new ArgumentException("Invalid gender", nameof(teacher.Gender));
            }

            if (string.IsNullOrEmpty(teacher.Position) || teacher.Position.Length > 30)
            {
                throw new ArgumentException("Position is required and should be maximum 30 characters long", nameof(teacher.Position));
            }

            if (string.IsNullOrEmpty(teacher.Education) || teacher.Education.Length > 55)
            {
                throw new ArgumentException("Education is required and should be maximum 55 characters long", nameof(teacher.Education));
            }

            if (string.IsNullOrWhiteSpace(teacher.PhoneNumber))
            {
                throw new ArgumentNullException(nameof(teacher.PhoneNumber), "Phone number is empty");
            }
            else
            {
                teacher.PhoneNumber = teacher.PhoneNumber.Trim();

                const string ukrainianPhoneNumberPattern = @"^\380\d{9}$";

                if (!Regex.IsMatch(teacher.PhoneNumber, ukrainianPhoneNumberPattern))
                {
                    throw new ArgumentException(nameof(teacher.PhoneNumber), "Phone number is invalid");
                }
            }

            if (string.IsNullOrWhiteSpace(teacher.Email) || teacher.Email.Length > 30)
            {
                throw new ArgumentException("Email is required and should be maximum 30 characters long", nameof(teacher.Email));
            }
        }
    }
}
