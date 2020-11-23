using FrameWork.EF;
using Microsoft.EntityFrameworkCore;
using PaintBook.Content.Infrastructure.EF.PostAndPostInfo;

namespace PaintBook.Content.Infrastructure.EF
{
    public class DBContextFactory : IDbContextFactory
    {
        private readonly DbContext _context;

        public DBContextFactory(ContentContext context)
        {
            // the context is new()ed up instead of being injected to avoid direct dependency on EF
            // not sure if this is good approach...but it removes direct dependency on EF from web tier
            _context = context;
        }

        public  DbContext GetDbContext()
        {
            return _context;
        }

        // see comment in IDbContextFactory inteface...
        //public void Dispose()
        //{
        //    if (_context != null)
        //    {
        //        _context.Dispose();
        //        GC.SuppressFinalize(this);
        //    }
        //}
    }
}
