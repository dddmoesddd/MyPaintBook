using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace FrameWork.EF
{
    public interface IDbContext
    {
        ChangeTracker ChangeTracker { get; }
        DbSet<T> Set<T>() where T : class;
        //IQueryable<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
        void Rollback();
    }
}
