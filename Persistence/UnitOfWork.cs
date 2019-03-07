using System.Threading.Tasks;
using mobilsentra.Core;

namespace mobilsentra.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MobilSentraDbContext db;

        public UnitOfWork(MobilSentraDbContext db)
        {
            this.db = db;
        }
        public async Task Complete()
        {
           await db.SaveChangesAsync();
        }
    }
}