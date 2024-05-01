
namespace PostsApi.Models;

public class Post{
    public required int Id { get; set; }
    public required string Content { get; set; } 
    public DateTime DateTime  { get; set; }
}