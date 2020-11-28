using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service
{
    public interface ICrudService<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> List();
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
    }
}
