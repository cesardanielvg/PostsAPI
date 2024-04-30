
using PostsApi.Controllers;
using PostsApi.Services;
using NSubstitute;
namespace APITests.Controllers;

public class PostsControllerTests
{
    [Fact]
    public void Get_UnderValidPosts_ReturnsPost(){
        var serviceSubstitte = Substitute.For<IPostsService>();
        PostsController s = new PostsController(serviceSubstitte);
    }
}