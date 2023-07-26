using Quiz.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
