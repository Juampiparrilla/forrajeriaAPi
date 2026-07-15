using Forrajeria.Application.Interfaces;

namespace Forrajeria.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ForrajeriaDbContext _context;  
        public UnitOfWork(ForrajeriaDbContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
