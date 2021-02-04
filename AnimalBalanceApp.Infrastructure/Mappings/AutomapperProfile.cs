using AnimalBalanceApp.Core.DTOs;
using AnimalBalanceApp.Core.Entities;
using AutoMapper;

namespace AnimalBalanceApp.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Comment, CommentDto>().ReverseMap();

            CreateMap<Security, SecurityDto>().ReverseMap();
        }
    }
}
