using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripsAPI.Entities;
using TripsAPI.Helpers.Response;

namespace TripsAPI.Services.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Table { get; }
        Task<TEntity> GetEntity(object id);
        Task<List<TEntity>> GetEntities();
        Task<TEntity> InsertEntity(TEntity entity);
        Task<TEntity> Find(Func<TEntity, bool> predicate);
        Task<TEntity> UpdateEntity(TEntity entity);
        Task InsertEntities(List<TEntity> entities);
        Task DeleteEntity(TEntity entity);
        Task<List<Trip>> GetAllCategories();
     
       
        Task<PagedResponse<Trip>> GetProductById(int userId, PaginationQuery paginationQuery);
        Task<PagedResponse<Trip>> GetAllProductPaged(PaginationQuery paginationQuery);
    }
}
