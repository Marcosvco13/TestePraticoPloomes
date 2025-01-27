using TestePraticoPloomes.Context;
using TestePraticoPloomes.IRepository;

namespace TestePraticoPloomes.Repository
{
    public class UnitOfWork : IUnitOFWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
