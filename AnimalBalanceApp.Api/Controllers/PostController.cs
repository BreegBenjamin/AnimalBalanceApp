using AnimalBalanceApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPost() 
        {
            var post = await _postRepository.GetPosts();
            return Ok(post);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostForId(int id) 
        {
            var post = await _postRepository.GetPostForId(id);
            return Ok(post);
        }
    }
}
