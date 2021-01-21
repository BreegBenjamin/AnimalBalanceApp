using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Infrastructure.Repositories
{
    public class BaseSocialRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AnimalBalanceAppContext _context;
        protected readonly DbSet<T> _entitis;
        public BaseSocialRepository(AnimalBalanceAppContext context)
        {
            _context = context;
            _entitis = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entitis.AsEnumerable();
        }
        public async Task<T> GetForId(int id)
        {
            return await _entitis.FindAsync(id);
        }
        public async Task<bool> Add(T entity)
        {
            await _context.AddAsync(entity);
            return true;
        }
        public void Update(T entity)
        {
            _entitis.Update(entity);
        }
        public async Task Delete(int id)
        {
            T entity = await GetForId(id);
            _entitis.Remove(entity);
        }
    }
}
