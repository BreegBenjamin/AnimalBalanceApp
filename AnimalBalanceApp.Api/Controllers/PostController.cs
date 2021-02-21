using AnimalBalanceApp.Api.Responses;
using AnimalBalanceApp.Core.CustomEntities;
using AnimalBalanceApp.Core.DTOs;
using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Core.QueryFilter;
using AnimalBalanceApp.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;

namespace AnimalBalanceApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _posService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public PostController(IPostService postRepository, IMapper mapper, IUriService uriService)
        {
            _posService = postRepository;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpGet(Name = nameof(GetPosts))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Produces(typeof(ApiResponse<IEnumerable<PostDto>>))]
        public IActionResult GetPosts([FromQuery] PostQueryFilter filters) 
        {
            var posts =  _posService.GetPosts(filters);
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            var metadata = new Metadata() 
            {
                TotalPages = posts.TotalPages,
                CurrentPage = posts.CurrentPage,
                PageSize = posts.PageSize,
                TotalCount = posts.TotalCount,
                HasNextsPage = posts.HasNextsPage,
                HasPreviousPage = posts.HasPreviousPage,
                NextPageUrl = _uriService.GetPostPaginatorUri(filters, Url.RouteUrl(nameof(GetPosts))),
                PreviousPageUrl = _uriService.GetPostPaginatorUri(filters, Url.RouteUrl(nameof(GetPosts))),
                Action = nameof(GetPosts)
            };
            var response = new ApiResponse<IEnumerable<PostDto>>(postsDto) 
            {
                Meta = metadata,
            };
            Response.Headers.Add("X-Pagination",  JsonSerializer.Serialize(metadata));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostForId(int id) 
        {
            var post = await _posService.GetPostForId(id);
            var postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _posService.InsertPost(post);
            postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            bool result = await _posService.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeletePost(int id )
        {
            if (id <= 0)
                return BadRequest("El id es incorrecto");

            bool result =  await _posService.DeletePost(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}