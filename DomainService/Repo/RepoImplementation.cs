using Domain.Entities;
using DomainService.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DomainService.Repo
{
    public class RepoImplementation<T> : IRepo<T> where T : class
    {
        private readonly Context.Context _context;

        public DbSet<T> dbSet;
        public RepoImplementation(Context.Context context)
        {
            this._context = context;
            this.dbSet = context.Set<T>();
        }
        public  void Create(T model)
        {
            try
            {
              dbSet.Add(model);
            }catch(Exception ex)
            {
                throw;
            }
        }

        public void Delete(T model)
        {
            try
            {
                dbSet.Remove(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] properties)
        {
            try
            {
                var query = properties.Aggregate(dbSet as IQueryable <T>, (current, property) => current.Include(property));
                return query.ToList();

            }catch(Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> where , params Expression<Func<T, object>>[] properties)
        {
            try
            {
                var query = properties.Aggregate(dbSet.Where(where) as IQueryable<T>, (current, property) => current.Include(property));
                return  query.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void Update(T model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Modified;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
