
using PostsApi.Models;
using PostsApi.Models.DTOs;

namespace PostsApi.Services;

public interface IPostsService
{
    Task<Post> CreatePostAsync(CreatePostDto post);
    Task<IEnumerable<Post>> GetPostListAsync();
    Task UpdatePostAsync(UpdatePostDto post);
    Task DeletePostAsync(int Id);
    Task<Post?> GetPostAsync(int id);
    
}