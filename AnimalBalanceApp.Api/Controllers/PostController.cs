using AnimalBalanceApp.Api.Responses;
using AnimalBalanceApp.Core.DTOs;
using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _posService;
        private readonly IMapper _mapper;
        public PostController(IPostService postRepository, IMapper mapper)
        {
            _posService = postRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPosts() 
        {
            var post =  _posService.GetPosts();
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(post);
            var response = new ApiResponse<IEnumerable<PostDto>>(postsDto);
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
