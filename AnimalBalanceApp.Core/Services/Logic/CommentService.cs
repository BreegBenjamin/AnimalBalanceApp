using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Exceptions;
using AnimalBalanceApp.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Services.Logic
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Comment>> GetCommentsForUserId(int userId)
        {
            return await _unitOfWork.CommentRepository.GetCommentsForUserId(userId);
        }
        public async Task<IEnumerable<Comment>> GetCommentsForPostId(int postId)
        {
            return await _unitOfWork.CommentRepository.GetCommentsForPostId(postId);
        }
    }
}