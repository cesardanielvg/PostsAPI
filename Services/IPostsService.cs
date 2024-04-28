
using PostsApi.Models;

namespace PostsApi.Services;

public interface IPostsService
{
    Task<Post> CreatePostAsync(PostDto post);
    Task<List<Post>> GetPostListAsync();
    Task<Post> UpdatePostAsync(Post post);
    Task DeletePostAsync(int Id);

    Task<Post> GetPostAsync(int id);
    
}