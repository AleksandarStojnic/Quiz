using Quiz.Interfaces;
using Quiz.Models.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;


namespace Quiz.Services
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> table;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            table = dbContext.Set<T>();
        }

        public async Task<T> GetById(int id)
        {
            return await table.Where(x => x.Id == id && x.Active).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            //TODO Think about overhead here becuase you are using list
            return await table.Where(x => x.Active).ToListAsync();
        }

        public void Create(T entity)
        {
            table.AddOrUpdate(entity);
        }

        public void Update(T entity)
        {
            table.AddOrUpdate(entity);
        }

        public void Delete(T entity)
        {
            //We will use soft delete that is why we decided on Repository pattern
            entity.Active = false;
            table.AddOrUpdate(entity);
        }

    }
}