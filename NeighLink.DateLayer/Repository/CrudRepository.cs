//using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class CrudRepository<T> where T : class
    {
        public neighlinkdbContext _dbContext;

        public CrudRepository()
        {
            //if (_dbContext == null)
            //{
            //    _dbContext = new CityToysContext();
            //}
        }

        public  async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync( id );
        }

        public async Task<List<T>> List()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public  IAsyncEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
                   .Where( predicate )
                   .AsAsyncEnumerable();
        }

        public  async Task<List<TResult>> GetAllBySelector<TResult>(System.Linq.Expressions.Expression<Func<T, TResult>> selector)
        {
            return await _dbContext.Set<T>().Select( selector ).ToListAsync();
        }

        public  Task<TResult> GetByIdBySelector<TResult>(int id, System.Linq.Expressions.Expression<Func<T, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Insert(T entity)
        {
            _dbContext.Set<T>().Add( entity );
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Entry( entity ).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync( id );
            _dbContext.Set<T>().Remove( entity );
            await _dbContext.SaveChangesAsync();
        }
    }
}
