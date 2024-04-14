namespace EduVerse.API.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AttendanceEntity?> GetAsync(int id)
        {
           return await _context.Attendances
                .Where(a => a.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<IList<AttendanceEntity>> ListAsync()
        {
            return await _context.Attendances
                .ToListAsync();
        }

        public async Task<int> AddAsync(AttendanceEntity attendance)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await _context.Attendances.AddAsync(attendance);
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

        public async Task<int> UpdateAsync(AttendanceEntity attendance)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Entry(attendance).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return attendance.Id;
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
