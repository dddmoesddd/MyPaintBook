using FrameWork.EF;
using PaintBook.Content.Domain.PostAndPostInfo.Model;
using System.Threading.Tasks;
namespace PaintBook.Content.Domain.PostAndPostInfo.Repository
{
    public  interface IPostRepository
    {
        void Add(Post post);
        void Update(Post post);
         Task<Post> FindAsync(long identity);
         Task<Post> FindByIdAsync(long id);
        IUnitOfWork UnitOfWork { get; }

    }
}
