namespace EduVerse.API.Repositories
{
    public class ParentRepository : IParentRepository
    {
        private readonly ApplicationDbContext _context;

        public ParentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ParentEntity?> GetAsync(int id)
        {
            return await _context.Parents
                 .Where(a => a.Id == id)
                 .SingleOrDefaultAsync();
        }

        public async Task<IList<ParentEntity>> ListAsync()
        {
            return await _context.Parents
                .ToListAsync();
        }

        public async Task<int> AddAsync(ParentEntity parent)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await _context.Parents.AddAsync(parent);
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

        public async Task<int> UpdateAsync(ParentEntity parent)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Entry(parent).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return parent.Id;
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
