using Go2Climb.API.Persistence.Contexts;
using Go2Climb.API.Shared.Domain.Repositories;
namespace Go2Climb.API.Shared.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
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