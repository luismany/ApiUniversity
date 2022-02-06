using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace University.BL.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly UniversityDbContext universityDbContext;
        public GenericRepository(UniversityDbContext universityDbContext)
        {
            this.universityDbContext = universityDbContext;
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("La entidad es nula");

            universityDbContext.Set<TEntity>().Remove(entity);
            await universityDbContext.SaveChangesAsync();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await universityDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await universityDbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            universityDbContext.Set<TEntity>().Add(entity);
            await universityDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            //universityDbContext.Entry(entity).State = EntityState.Modified;
            universityDbContext.Set<TEntity>().AddOrUpdate(entity);
            await universityDbContext.SaveChangesAsync();
            return entity;
        }
       
    }
}
