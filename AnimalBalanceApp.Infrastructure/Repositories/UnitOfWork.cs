using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Infrastructure.Data;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AnimalBalanceAppContext _context;
        private readonly IPostRepository _postRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Comment> _commentRepository;
        public UnitOfWork(AnimalBalanceAppContext context)
        {
            _context = context;
        }
        public IPostRepository PostRepository => _postRepository ?? new PostRepository(_context);

        public IRepository<User> UserRepository => _userRepository ?? new BaseSocialRepository<User>(_context);

        public IRepository<Comment> CommentRepository => _commentRepository ?? new BaseSocialRepository<Comment>(_context);

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
        public void SaveChanged()
        {
            _context.SaveChanges();
        }
        public async Task<bool> SaveChangedAsync()
        {
            int row =  await _context.SaveChangesAsync();
            return row > 0;
        }
    }
}
