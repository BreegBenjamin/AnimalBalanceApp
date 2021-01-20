using AnimalBalanceApp.Core.DTOs;
using AnimalBalanceApp.Core.Entitis;
using AutoMapper;

namespace AnimalBalanceApp.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
        }
    }
}
