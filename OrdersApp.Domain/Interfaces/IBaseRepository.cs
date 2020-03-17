using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdersApp.Models.Base;

namespace OrdersApp.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetBaseQuery();
    }
}