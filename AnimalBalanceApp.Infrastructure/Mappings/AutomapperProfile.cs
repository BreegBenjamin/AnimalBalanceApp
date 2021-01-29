using AnimalBalanceApp.Core.DTOs;
using AnimalBalanceApp.Core.Entities;
using AutoMapper;

namespace AnimalBalanceApp.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
        }
    }
}
