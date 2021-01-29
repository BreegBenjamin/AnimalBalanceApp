using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Infrastructure.Repositories
{
    public class CommentRepository : BaseSocialRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AnimalBalanceAppContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Comment>> GetCommentsForUserId(int IdUser)
        {
            return await _entitis.Where(x => x.UserId == IdUser).ToListAsync();
        }
        public async Task<IEnumerable<Comment>> GetCommentsForPostId(int IdPost)
        {
            return await _entitis.Where(x=> x.PostId == IdPost).ToListAsync();
        }
    }
}
