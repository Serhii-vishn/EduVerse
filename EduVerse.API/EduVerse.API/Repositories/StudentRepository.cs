namespace EduVerse.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StudentEntity?> GetAsync(int id)
        {
            return await _context.Students
                 .Where(s => s.Id == id)
                 .SingleOrDefaultAsync();
        }

        public async Task<StudentEntity?> GetAllAsync(int id)
        {
            return await _context.Students
                 .Where(a => a.Id == id)
                 .Include(g => g.Group)
                 .Include(p => p.Parents)
                 .Include(a => a.Attendance)
                 .Include(g => g.Grades)
                 .SingleOrDefaultAsync();
        }

        public async Task<IList<StudentEntity>> ListAsync()
        {
            return await _context.Students
                .ToListAsync();
        }

        public async Task<int> AddAsync(StudentEntity student)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return result.Entity.Id;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<int> UpdateAsync(StudentEntity student)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Entry(student).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return student.Id;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Entry((await GetAsync(id)) !).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return id;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
