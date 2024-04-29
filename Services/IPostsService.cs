
using PostsApi.Models;

namespace PostsApi.Services;

public interface IPostsService
{
    Task<bool> CreatePost(PostDto post);
    Task<List<Post>> GetPostList();
    Task<Post> UpdatePost(Post post);
    Task<bool> DeletePost(int Id);
    
}