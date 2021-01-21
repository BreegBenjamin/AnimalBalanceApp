using AnimalBalanceApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Interfaces
{
    public interface IRepository <T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetForId(int id);
        Task<bool> Add(T entity);
        void Update(T entity);
        Task Delete(int id);
    }
}
