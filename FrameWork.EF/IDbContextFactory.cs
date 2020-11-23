using Microsoft.EntityFrameworkCore;

namespace FrameWork.EF
{
    public  interface IDbContextFactory
    {
        DbContext GetDbContext();
    }
}
