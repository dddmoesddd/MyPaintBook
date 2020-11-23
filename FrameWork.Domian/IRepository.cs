using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrameWork.Domian
{
    public   interface IRepository<T> where  T :class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T entity);
        Task<int> Delete(int id);
        Task<int> Update(T entity);
    }
}
