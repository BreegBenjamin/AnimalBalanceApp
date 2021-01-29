using AnimalBalanceApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsForUserId(int userId);
        Task<IEnumerable<Comment>> GetCommentsForPostId(int postId);
    }
}
