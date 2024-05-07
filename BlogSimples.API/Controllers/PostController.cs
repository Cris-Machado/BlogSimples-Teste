using Microsoft.AspNetCore.Mvc;
using BlogSimples.API.Domain.Interfaces.Repositories;
using BlogSimples.API.Domain.Services;
using BlogSimples.API.Presentation.Controllers.Base;
using BlogSimples.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using BlogSimples.API.Hubs;

namespace BlogSimples.API.Presentation.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService _postService;
        private readonly IHubContext<WebSocketHub> _hubContext;

        public PostController(IPostService postService, IHubContext<WebSocketHub> hubContext)
        {
            _postService = postService;
            _hubContext = hubContext;
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

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", post, "PostInserted");

            return Ok(result);
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] PostDto model)
        {
            var post = new Post(model.Id, model.UserId, model.Title, model.Description);
            var result = await _postService.UpdateAsync(post);

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", post, "PostUpdated");

            return Ok(result);
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteUser([FromQuery] Guid postId)
        {
            var storedPost = await _postService.FindByIdAsync(postId);
            var result = await _postService.DeleteAsync(storedPost);

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", storedPost, "PostDeleted");

            return Ok(result);
        }
        #endregion
    }
}
