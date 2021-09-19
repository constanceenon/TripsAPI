using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripsAPI.Entities;
using TripsAPI.Helpers.Response;
using TripsAPI.Services.Interfaces;

namespace TripsAPI.Data.Repository
{
    public class TripsRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private DbContext _dbContext;
        private ApplicationDbContext _context;
        private DbSet<TEntity> _entities;
        public TripsRepository(DbContext dbContext, ApplicationDbContext context)
        {
            _dbContext = dbContext;
            _context = context;
        }

        public IQueryable<TEntity> Table => Entities;

        public async Task DeleteEntity(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");


            Entities.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetEntities()
        {
            return await Entities.ToListAsync();
        }

        public async Task<TEntity> GetEntity(object id)
        {
            return await Entities.FindAsync(id) as TEntity;
        }

        public async Task InsertEntities(List<TEntity> entities)
        {
            if (entities == null || entities.Count == 0)
                throw new ArgumentNullException("entities");


            await Entities.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> InsertEntity(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");


            await Entities.AddAsync(entity);


            await _dbContext.SaveChangesAsync();
            return entity;

        }

        public async Task<TEntity> UpdateEntity(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Entities.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Trip>> FindAll()
        {
            var result = await _dbContext.Set<Trip>().ToListAsync();
            return result;
        }

        private DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _dbContext.Set<TEntity>();
                }
                return _entities;
            }
        }
        public Task<PagedResponse<Trip>> GetAllProductPaged(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }
        public Task<PagedResponse<Trip>> GetProductById(int userId, PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        public Task<List<Trip>> GetAllCategories()
        {
            throw new NotImplementedException();
        }
    }
}
