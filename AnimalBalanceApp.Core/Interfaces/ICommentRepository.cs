using AnimalBalanceApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsForUserId(int IdUser);
        Task<IEnumerable<Comment>> GetCommentsForPostId(int IdPost);
    }
}
