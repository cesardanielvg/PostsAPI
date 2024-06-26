using Microsoft.AspNetCore.Mvc;
using PostsApi.Models;
using PostsApi.Models.DTOs;
using PostsApi.Services;

namespace PostsApi.Controllers;

[ApiController]
[Route("[controller]/")]
public class PostsController(IPostsService _postsService) : ControllerBase
{
    [HttpPost]
    public async Task<Post> InsertPostAsync([FromBody] CreatePostDto createPostDto) => await _postsService.CreatePostAsync(createPostDto);

    [HttpGet]
    [Route("{Id}")]
    public async Task<ActionResult> GetByIdAsync([FromRoute] int Id){
    
        var post =  await _postsService.GetPostAsync(Id);
        return post==null? NotFound(): Ok(post);
    }

    [HttpGet]
    public async Task<IEnumerable<Post>> GetPostsAsync() => await _postsService.GetPostListAsync();

    [HttpPut]//TODO
    public async Task<ActionResult> UpdatePostAsync([FromBody] UpdatePostDto updatePostDto) {
        try{
            await _postsService.UpdatePostAsync(updatePostDto);
            return NoContent();
        }
        catch(KeyNotFoundException){
            return NotFound();
        }
        
    } 

    /// <summary>
    /// TODO //todo TODO
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{Id}")]
    public async Task<ActionResult> DeletePostAsync([FromRoute] int Id) {
        try{
            await _postsService.DeletePostAsync(Id);
            return NoContent();
        }
        catch(KeyNotFoundException){
            return NotFound();
        }
    } 

}
