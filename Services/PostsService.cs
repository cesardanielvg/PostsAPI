using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostsApi.Models;

namespace PostsApi.Services;

public class PostsService(IDbService _dbService) : IPostsService
{
    public async Task<bool> CreatePost(PostDto post)
    {
        var result =
            await _dbService.EditData(
                "INSERT INTO public.Posts (Content,Datetime) VALUES (@Content, @DateTime)",
                new Post(){
                    Content=post.Content
                });
        return true;
    }

    public async Task<List<Post>> GetPostList()
    {
        var postList = await _dbService.GetAll<Post>("SELECT * FROM public.Posts", new { });
        return postList;
    }


    public async Task<Post> GetPost(int id)
    {
        var post = await _dbService.GetAsync<Post>("SELECT * FROM public.Posts where id=@id", new {id});
        return post;
    }

    public async Task<Post> UpdatePost(Post post)
    {
        var updatePost =
            await _dbService.EditData(
                "Update public.Posts SET name=@Content, Datetime=@DateTime WHERE id=@Id",
                post);
        return post;
    }

    public async Task<bool> DeletePost(int id)
    {
        var deletePost = await _dbService.EditData("DELETE FROM public.Posts WHERE id=@Id", new {id});
        return true;
    }
    
}