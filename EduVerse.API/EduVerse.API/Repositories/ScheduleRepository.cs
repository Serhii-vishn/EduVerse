namespace EduVerse.API.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ApplicationDbContext _context;

        public ScheduleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ScheduleEntity?> GetAsync(int id)
        {
            return await _context.Schedules
                .Where(s => s.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<IList<ScheduleEntity>> ListAsync()
        {
            return await _context.Schedules
                .ToListAsync();
        }

        public async Task<int> AddAsync(ScheduleEntity schedule)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await _context.Schedules.AddAsync(schedule);
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

        public async Task<int> UpdateAsync(ScheduleEntity schedule)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Entry(schedule).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return schedule.Id;
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
