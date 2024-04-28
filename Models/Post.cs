
namespace PostsApi.Models;

public class Post{
    public int Id { get; set;}
    public string? Content { get; set; } 
    public DateTime DateTime  {get; } = DateTime.Now;
}