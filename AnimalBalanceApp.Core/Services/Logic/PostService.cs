using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Services.Logic
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Post> GetPostForId(int id)
        {
            return await _unitOfWork.PostRepository.GetForId(id);
        }
        public IEnumerable<Post> GetPosts()
        {
            return _unitOfWork.PostRepository.GetAll();
        }
        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return await _unitOfWork.SaveChangedAsync();
        }
        public async Task InsertPost(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetForId(post.UserId);
            if (user == null)
                throw new Exception("No se encontro el usuario");
            await _unitOfWork.PostRepository.Add(post);
        }
        public async Task<bool> UpdatePost(Post post)
        {
            _unitOfWork.PostRepository.Update(post);
            return await _unitOfWork.SaveChangedAsync();
        }
        public async Task<IEnumerable<Post>> GetPostsById(int userId) 
        {
            return await _unitOfWork.PostRepository.GetPostsByUser(userId);
        }
    }
}
