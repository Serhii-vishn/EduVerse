namespace EduVerse.API.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _context;

        public GradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GradeEntity?> GetAsync(int id)
        {
            return await _context.Grades
                 .Where(a => a.Id == id)
                 .SingleOrDefaultAsync();
        }

        public async Task<IList<GradeEntity>> ListAsync()
        {
            return await _context.Grades
                .ToListAsync();
        }

        public async Task<int> AddAsync(GradeEntity grade)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await _context.Grades.AddAsync(grade);
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

        public async Task<int> UpdateAsync(GradeEntity grade)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Entry(grade).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return grade.Id;
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
