
using PostsApi.Models;

namespace PostsApi.Services;

public class PostsService(IDbService _dbService) : IPostsService
{
    public async Task<Post> CreatePostAsync(PostDto postDto)
    {
        Post post = new(){ Content = postDto.Content };
        
        var result = await _dbService.EditDataAsync(
                "INSERT INTO public.Posts (Content,Datetime) VALUES (@Content, @DateTime)", post);

        post.Id = result;

        return post;
    }

    public async Task<List<Post>> GetPostListAsync()
    {
        var postList = await _dbService.GetAll<Post>("SELECT * FROM public.Posts", new { });
        return postList;
    }


    public async Task<Post> GetPostAsync(int id)
    {
        var post = await _dbService.GetAsync<Post>("SELECT * FROM public.Posts where id=@id", new {id});
        return post;
    }

    public async Task<Post> UpdatePostAsync(Post post)
    {
        var updatePost =
            await _dbService.EditDataAsync(
                "Update public.Posts SET name=@Content, Datetime=@DateTime WHERE id=@Id",
                post);
        return post;
    }

    public async Task DeletePostAsync(int id)
    {
        var deletePost = await _dbService.EditDataAsync("DELETE FROM public.Posts WHERE id=@Id", new {id});
        // TODO catch not found?
    }
    
}