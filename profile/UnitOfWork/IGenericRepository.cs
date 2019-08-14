
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace profile.Models
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity t);
        Task<TEntity> AddAsyn(TEntity t);
        //Task<TEntity> UpdateAsyn(TEntity t, object key);
        void Delete(object id);
        //Task<ActionResult<TEntity>> GetByID(long id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
