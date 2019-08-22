
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace profile.Models
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task <TEntity> Add(TEntity t);
        void Update(TEntity t);
        //Task<TEntity> UpdateAsyn(TEntity t, object key);
        void Delete(TEntity t);
        Task <TEntity> GetByID(long id);
        Task <IEnumerable<TEntity>> GetAll();
    }
}
