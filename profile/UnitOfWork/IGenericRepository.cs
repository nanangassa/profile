using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace profile.Models
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity t);
        Task<TEntity> AddAsyn(TEntity t);
        Task<TEntity> UpdateAsyn(TEntity t, object key);
        void Delete(object id);
    }
}
