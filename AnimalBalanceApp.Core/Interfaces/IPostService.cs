using AnimalBalanceApp.Core.CustomEntities;
using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.QueryFilter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Interfaces
{
    public interface IPostService
    {
        PagedList<Post> GetPosts(PostQueryFilter filters);
        Task<Post> GetPostForId(int id);
        Task InsertPost(Post post);
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
        Task<IEnumerable<Post>> GetPostsByUserId(int userId);
    }
}
