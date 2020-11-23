using FrameWork.Domian;
using PaintBook.Content.Infrastructure.EF.PostAndPostInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaintBook.Content.Infrastructure.EF
{
    public abstract class ContetntRepository<T> : IRepository<T> where  T: class
    {
        protected readonly ContentContext _context;
        public ContetntRepository(ContentContext context)
        {
            _context = context;
        }
        public Task<int> Add(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
