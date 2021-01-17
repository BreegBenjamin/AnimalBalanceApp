using AnimalBalanceApp.Core.Entitis;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AnimalBalanceApp.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AnimalBalanceAppContext _context;
        public PostRepository(AnimalBalanceAppContext context)
        {
            _context = context;
        }

        public async Task<Post> GetPostForId(int id)
        {
            using (_context) 
            {
                return await _context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            }
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            using (_context)
            {
                return await _context.Posts.ToListAsync();
            }
        }
    }
}
