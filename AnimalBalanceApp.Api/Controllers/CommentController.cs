using AnimalBalanceApp.Api.Responses;
using AnimalBalanceApp.Core.DTOs;
using AnimalBalanceApp.Core.Exceptions;
using AnimalBalanceApp.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [ActionName("GetCommentsPost")]
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetCommentsForPostId(int postId) 
        {
            var response = await _getCommentsResponse(postId, false);
            return Ok(response);
        }
        [ActionName("GetCommentsUser")]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCommentsForUserId(int userId) 
        {
            var response = await _getCommentsResponse(userId, true);
            return Ok(response);
        }
        private async Task<ApiResponse<IEnumerable<CommentDto>>> _getCommentsResponse(int id, bool isUser) 
        {
            if (id <= 0)
                throw new ParameterException("El Id ingresado es invalido");
            var commentResult = (isUser)? await _commentService.GetCommentsForUserId(id) : await _commentService.GetCommentsForPostId(id);

            var comment = _mapper.Map<IEnumerable<CommentDto>>(commentResult);
            var response = new ApiResponse<IEnumerable<CommentDto>>(comment);
            return response;
        }
    }
}
