using Microsoft.AspNetCore.Mvc;
using PostsApi.Models;
using PostsApi.Services;

namespace PostsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController(ILogger<PostsController> _logger, IPostsService _postsService) : ControllerBase
{
   
    #region CREATE 

    [HttpPost]
    public async Task<IEnumerable<Post>> InsertPost()
    {
        return await _postsService.GetPostListAsync();
    }

    [HttpGet]
    [Route("/{Id}")]
    public async Task<Post> GetByIdAsync([FromRoute]int Id)
    {
        return await _postsService.GetPostAsync(Id);
    }

    #endregion CREATE 

    #region RETRIEVE 
    
    [HttpGet]
    public async Task<IEnumerable<Post>> GetPostsAsync()
    {
        return await _postsService.GetPostListAsync();
    }

    [HttpGet]
    [Route("/{Id}")]
    public async Task<Post> GetByIdAsync([FromRoute]int Id)
    {
        return await _postsService.GetPostAsync(Id);
    }

    #endregion RETRIEVE 

}
