using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Infrastructure.Repositories
{
    public class PostRepository : BaseSocialRepository<Post>, IPostRepository
    {
        public PostRepository(AnimalBalanceAppContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Post>> GetPostsByUser(int userId)
        {
            return await _entitis.Where(x=> x.UserId == userId).ToListAsync();
        }
    }
}
