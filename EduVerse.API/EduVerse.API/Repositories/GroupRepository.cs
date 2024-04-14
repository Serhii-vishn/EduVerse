namespace EduVerse.API.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;
        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GroupEntity?> GetAsync(int id)
        {
            return await _context.Groups
                 .Where(a => a.Id == id)
                 .SingleOrDefaultAsync();
        }

        public async Task<IList<GroupEntity>> ListAsync()
        {
            return await _context.Groups
                .ToListAsync();
        }

        public async Task<int> AddAsync(GroupEntity group)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await _context.Groups.AddAsync(group);
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

        public async Task<int> UpdateAsync(GroupEntity group)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Entry(group).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return group.Id;
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
