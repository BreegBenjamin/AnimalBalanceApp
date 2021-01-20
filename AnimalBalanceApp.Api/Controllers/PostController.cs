using AnimalBalanceApp.Api.Responses;
using AnimalBalanceApp.Core.DTOs;
using AnimalBalanceApp.Core.Entitis;
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
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts() 
        {
            var post = await _postRepository.GetPosts();
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(post);
            var response = new ApiResponse<IEnumerable<PostDto>>(postsDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostForId(int id) 
        {
            var post = await _postRepository.GetPostForId(id);
            var postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }
        [HttpPost]

        public async Task<IActionResult> InsertPost(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postRepository.InsertPost(post);
            postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            bool result = await _postRepository.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeletePost(int id )
        {
            if (id <= 0)
                return BadRequest("El id es incorrecto");

            bool result =  await _postRepository.DeletePost(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
