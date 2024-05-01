
using Microsoft.AspNetCore.Mvc;
using PostsApi.Controllers;
using PostsApi.Models;
using PostsApi.Models.DTOs;
using PostsApi.Services;

namespace APITests.Controllers;

public class PostsControllerTests
{
    [Fact]
    public async Task GetPostsAsync_UnderValidPosts_ReturnsPosts(){
        // Arrange
        var postServiceSubstitute = Substitute.For<IPostsService>();
        IEnumerable<Post> postsLIsts =  [ new(){ Content = "One Post" ,Id = 1, DateTime = DateTime.Now } ,
        new(){ Content = "Anothe Post" ,Id = 2, DateTime = DateTime.Now }];

        postServiceSubstitute.GetPostListAsync().Returns(postsLIsts);

        // Act        
        PostsController postsController = new(postServiceSubstitute);
        var responsePosts = await postsController.GetPostsAsync();

        // Assert
        responsePosts.Should().BeEquivalentTo(postsLIsts);
    }

    [Fact]
    public async Task GetPostAsync_UnderValidPost_ReturnsPost(){
        // Arrange
        var postServiceSubstitute = Substitute.For<IPostsService>();
        Post post =  new(){Content = "One Post" ,Id = 1, DateTime = DateTime.Now};
        postServiceSubstitute.GetPostAsync(Arg.Any<int>()).Returns(post);

        // Act        
        PostsController postsController = new(postServiceSubstitute);
        var okObjectResult = await postsController.GetByIdAsync(default) as OkObjectResult;

        // Assert
        okObjectResult!.Value.Should().BeEquivalentTo(post);
    }

    [Fact]
    public async Task InsertPostAsync_UnderValidPost_ReturnsPost(){
        // Arrange
        var postServiceSubstitute = Substitute.For<IPostsService>();
        Post post =  new(){Content = "One Post" ,Id = 1, DateTime = DateTime.Now};
        postServiceSubstitute.CreatePostAsync(Arg.Any<CreatePostDto>()).Returns(post);

        // Act        
        PostsController postsController = new(postServiceSubstitute);
        var postResponse = await postsController.InsertPostAsync(default!);

        // Assert
        postResponse!.Should().BeEquivalentTo(post);
    }

    
}