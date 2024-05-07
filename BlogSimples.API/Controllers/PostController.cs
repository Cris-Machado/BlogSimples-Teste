using Microsoft.AspNetCore.Mvc;
using BlogSimples.API.Domain.Interfaces.Repositories;
using BlogSimples.API.Domain.Services;
using BlogSimples.API.Presentation.Controllers.Base;
using BlogSimples.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace BlogSimples.API.Presentation.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        #region Methods

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAll()
        {
            var result = await _postService.FindAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> InsertUser([FromBody] PostDto model)
        {
            var post = new Post(model.UserId, model.Title, model.Description);
            var result = await _postService.InsertAsync(post);

            return Ok(result);
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] PostDto model)
        {
            var post = new Post(model.Id, model.UserId, model.Title, model.Description);
            var result = await _postService.UpdateAsync(post);

            return Ok(result);
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteUser([FromQuery] Guid postId)
        {
            var storedPost = await _postService.FindByIdAsync(postId);
            var result = await _postService.DeleteAsync(storedPost);

            return Ok(result);
        }
        #endregion
    }
}
