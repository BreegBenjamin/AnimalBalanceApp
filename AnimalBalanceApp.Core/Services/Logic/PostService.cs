using AnimalBalanceApp.Core.CustomEntities;
using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Exceptions;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Core.QueryFilter;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Services.Logic
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public PostService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }
        public PagedList<Post> GetPosts(PostQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var posts = _unitOfWork.PostRepository.GetAll();
            if (filters.UserId != null)
                posts = posts.Where(x => x.UserId == filters.UserId);
            else if (filters.Date != null)
                posts = posts.Where(x => x.DatePost.ToShortDateString() == filters.Date?.ToShortDateString());
            else if (filters.Description != null)
                posts = posts.Where(x => x.PostDescription.ToLower().Contains(filters.Description.ToLower()));

            var pagedPost = PagedList<Post>.Create(posts, filters.PageNumber, filters.PageSize);
            return pagedPost;
        }
        public async Task<Post> GetPostForId(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }
        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return await _unitOfWork.SaveChangedAsync();
        }
        public async Task InsertPost(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);
            if (user == null)
                throw new BusinessException("No se encontro el usuario");
            post.DatePost = DateTime.Now;
            await _unitOfWork.PostRepository.Add(post);
        }
        public async Task<bool> UpdatePost(Post post)
        {
            var postExists = await _unitOfWork.PostRepository.GetById(post.Id);
            postExists.PostDescription = post.PostDescription;
            postExists.Title = post.Title;
            postExists.Category = post.Category;

            _unitOfWork.PostRepository.Update(postExists);
            return await _unitOfWork.SaveChangedAsync();
        }
        public async Task<IEnumerable<Post>> GetPostsByUserId(int userId) 
        {
            return await _unitOfWork.PostRepository.GetPostsByUser(userId);
        }
    }
}
