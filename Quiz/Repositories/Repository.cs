using Quiz.Context;
using Quiz.Interfaces;
using Quiz.Models.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;


namespace Quiz.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly DatabaseContext _dbContext;
        protected readonly DbSet<T> table;

        public Repository(DatabaseContext dbContext)
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
            table.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            table.AddOrUpdate(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            //We will use soft delete that is why we decided on Repository pattern
            entity.Active = false;
            table.AddOrUpdate(entity);
            _dbContext.SaveChanges();
        }

    }
}