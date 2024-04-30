
using System.Data;
using Npgsql;
using Dapper;
using PostsApi.Models;
using PostsApi.Models.DTOs;
using PostsApi.Database;

namespace PostsApi.Services;

public class PostsService(IConfiguration _configuration) : IPostsService
{
    private readonly string _connectionString = _configuration.GetConnectionString("PostsDb")!;

    public IDbConnection Connection
    {
        get
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
    public async Task<Post> CreatePostAsync(CreatePostDto postDto)
    {
        Post post = new(){ 
            Id = default,
            Content = postDto.Content,
            DateTime = DateTime.Now
            };
        post.Id = await Connection.ExecuteScalarAsync<int>(PostsSqlQueries.CREATEPOST, post);;
        
        return post;
    }

    public async Task<IEnumerable<Post>> GetPostListAsync()
    {
        var postList = await Connection.QueryAsync<Post>(PostsSqlQueries.SELECTFROMPOSTS, new { });
        return postList;
    }


    public async Task<Post?> GetPostAsync(int id)
    {
        var post = await Connection.QueryFirstOrDefaultAsync<Post>(PostsSqlQueries.SELECTPOSTWHEREID, new {id});
        return post;
    }

    public async Task UpdatePostAsync(UpdatePostDto postDto)
    {
        var postToUpdate = await GetPostAsync(postDto.Id) ?? throw new KeyNotFoundException();
        postToUpdate.Content = postDto.Content;
        await Connection.ExecuteAsync(PostsSqlQueries.UPDATEPOSTWHEREID,postToUpdate);
    }

    public async Task DeletePostAsync(int id)
    {
        _ = await GetPostAsync(id) ?? throw new KeyNotFoundException();
        await Connection.ExecuteAsync(PostsSqlQueries.DELETEPOSTWHEREID, new {id});
    }
    
}