using AnimalBalanceApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostsByUser(int userId);
    }
}
