using AnimalBalanceApp.Core.Entitis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPostForId(int id);
        Task InsertPost(Post post);
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
        Task<bool> SaveChanges();
    }
}
