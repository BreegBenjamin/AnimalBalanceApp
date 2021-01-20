using AnimalBalanceApp.Core.Entitis;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            => await _context.Posts.FirstOrDefaultAsync(x => x.PostId == id);

        public async Task<IEnumerable<Post>> GetPosts()
        {
            using (_context)
            {
                return await _context.Posts.ToListAsync();
            }
        }
        public async Task InsertPost(Post post)
        {
            using (_context) 
            {
                _context.Posts.Add(post);
                await SaveChanges();
            }
        }
        public async Task<bool> UpdatePost(Post post)
        {
            using (_context) 
            {
                var currentPost = await GetPostForId(post.PostId);
                currentPost.PostDescription = post.PostDescription;
                currentPost.DatePost = DateTime.Now;
                currentPost.Category = post.Category;
                return await SaveChanges();
            }
        }
        public async Task<bool> DeletePost(int id)
        {
            using (_context)
            {
                var currentPost = await GetPostForId(id);
                if (currentPost == null)
                    return false;
                _context.Posts.Remove(currentPost);
                return await SaveChanges();
            }
        }
        public async Task<bool> SaveChanges()
        {
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }

    }
}
