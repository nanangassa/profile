


//using System;
//using System.Linq;
//using System.Linq.Expressions;
//using Microsoft.EntityFrameworkCore;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using profile.Models;

namespace profile.UnitOfWork
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        internal Storecontext _context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(Storecontext context)
        {
            this._context = context;
            this.dbSet = context.Set<TEntity>();
        }
        // public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)

        public virtual IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();

        }


        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            //return _context.Set<TEntity>().Find(id);
            return dbSet.Find(id);
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsyn()
        {
            IQueryable<TEntity> query = dbSet;
            // return await _context.Set<TEntity>().ToListAsync(); /no ??
            return await query.ToListAsync();
        }


        public virtual TEntity Add(TEntity t)
        {
            // _context.Set<TEntity>().Add(t); no
            dbSet.Add(t);
            //     _context.SaveChanges();
            return t;
        }

        public virtual async Task<TEntity> AddAsyn(TEntity t)
        {
            // await _context.Set<TEntity>().AddAsync(t);
            await dbSet.AddAsync(t);
            return t;
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }


        //TEntity IGenericRepository<TEntity>.Update(TEntity t, object key)
        //{

        //    if (t == null)
        //        return null;
        //    TEntity exist = _context.Set<TEntity>().Find(key);
        //    if (exist != null)
        //    {
        //        _context.Entry(exist).CurrentValues.SetValues(t);
        //        _context.SaveChanges();
        //    }
        //    return exist;
        //}

        async Task<TEntity> IGenericRepository<TEntity>.UpdateAsyn(TEntity t, object key)
        {
            {
                if (t == null)
                    return null;
                TEntity exist = await _context.Set<TEntity>().FindAsync(key);
                if (exist != null)
                {
                    _context.Entry(exist).CurrentValues.SetValues(t);
                    await _context.SaveChangesAsync();
                }
                return exist;
            }
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        //public Task<int> DeleteAsyn(object id)
        public virtual async Task DeleteAsync(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }


    }

}






