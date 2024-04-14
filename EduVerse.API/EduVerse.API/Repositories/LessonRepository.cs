namespace EduVerse.API.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDbContext _context;

        public LessonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LessonEntity?> GetAsync(int id)
        {
            return await _context.Lessons
                 .Where(a => a.Id == id)
                 .SingleOrDefaultAsync();
        }

        public async Task<IList<LessonEntity>> ListAsync()
        {
            return await _context.Lessons
                .ToListAsync();
        }

        public async Task<int> AddAsync(LessonEntity lesson)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await _context.Lessons.AddAsync(lesson);
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

        public async Task<int> UpdateAsync(LessonEntity lesson)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Entry(lesson).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return lesson.Id;
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
