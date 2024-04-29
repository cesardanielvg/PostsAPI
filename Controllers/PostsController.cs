using Microsoft.AspNetCore.Mvc;
using PostsApi.Models;
using PostsApi.Services;

namespace PostsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController(ILogger<PostsController> _logger, IPostsService _postsService) : ControllerBase
{
   
    [HttpGet(Name = "GetPosts")]
    public async Task<IEnumerable<Post>> Get()
    {
        return await _postsService.GetPostList();
    }
}
