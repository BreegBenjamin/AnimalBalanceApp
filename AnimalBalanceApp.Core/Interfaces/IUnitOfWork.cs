using AnimalBalanceApp.Core.Entities;
using System;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        IRepository<User> UserRepository { get; }
        ICommentRepository CommentRepository { get; }
        ISecurityRepository SecurityRepository { get; }
        void SaveChanged();
        Task<bool> SaveChangedAsync();
    }
}
