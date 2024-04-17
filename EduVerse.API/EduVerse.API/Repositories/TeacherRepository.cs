namespace EduVerse.API.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TeacherEntity?> GetAsync(int id)
        {
            return await _context.Teachers
                 .Where(a => a.Id == id)
                 .SingleOrDefaultAsync();
        }

        public async Task<TeacherEntity?> GetAllAsync(int id)
        {
            return await _context.Teachers
                 .Where(a => a.Id == id)
                 .Include(g => g.Groups)
                 .Include(l => l.Lessons)
                 .SingleOrDefaultAsync();
        }

        public async Task<IList<TeacherEntity>> ListAsync()
        {
            return await _context.Teachers
                .ToListAsync();
        }

        public async Task<int> AddAsync(TeacherEntity teacher)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await _context.Teachers.AddAsync(teacher);
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

        public async Task<int> UpdateAsync(TeacherEntity teacher)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Entry(teacher).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return teacher.Id;
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
