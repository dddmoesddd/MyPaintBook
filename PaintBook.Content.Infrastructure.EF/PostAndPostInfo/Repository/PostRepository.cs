using FrameWork.EF;
using Microsoft.EntityFrameworkCore;
using PaintBook.Content.Application.Contract;
using PaintBook.Content.Domain.PostAndPostInfo.Model;
using PaintBook.Content.Domain.PostAndPostInfo.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PaintBook.Content.Infrastructure.EF.PostAndPostInfo.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ContentContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        private ContetntRepository<PostDataModel> genricRepo { get; set; }
        public PostRepository(ContentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //public PostRepository(ContentContext context)
        //{
        //    _context = context ?? throw new ArgumentNullException(nameof(context));
        //}



        public void Add(Post post)
        {
         _context.Posts.Add(post);
            var st = _context.Entry(post).State;

        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
                   
        }

        public async Task<Post> FindAsync(long identity)
        {
            var buyer = await _context.Posts
                .Where(b => b.Id == identity)
                .SingleOrDefaultAsync();

            return buyer;
        }

        public async Task<Post> FindByIdAsync(long id)
        {
            var buyer = await _context.Posts
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();

            return buyer;
        }
    }
}
