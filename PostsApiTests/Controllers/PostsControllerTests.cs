
using Microsoft.AspNetCore.Mvc;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using PostsApi.Controllers;
using PostsApi.Models;
using PostsApi.Models.DTOs;
using PostsApi.Services;

namespace APITests.Controllers;

public class PostsControllerTests
{
    [Fact]
    public async Task GetPostsAsync_GivenValidPosts_ReturnsPosts(){
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
    public async Task GetPostAsync_GivenValidPost_ReturnsPost(){
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
    public async Task GetByIdAsync_GivenNotFound_ReturnsNotFound(){
        // Arrange
        var postServiceSubstitute = Substitute.For<IPostsService>();
        postServiceSubstitute.GetPostAsync(Arg.Any<int>()).ReturnsNull();

        // Act        
        PostsController postsController = new(postServiceSubstitute);
        var getByIdResponse = await postsController.GetByIdAsync(default!) as NotFoundResult;

        // Assert
        getByIdResponse!.Should().NotBeNull();
    }

    [Fact]
    public async Task InsertPostAsync_GivenValidPost_ReturnsPost(){
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

    [Fact]
    public async Task DeletePostAsync_GivenTaskCompleted_ReturnsNoContent(){
        // Arrange
        var postServiceSubstitute = Substitute.For<IPostsService>();
        postServiceSubstitute.DeletePostAsync(Arg.Any<int>()).Returns(Task.CompletedTask);

        // Act        
        PostsController postsController = new(postServiceSubstitute);
        var deleteResponse = await postsController.DeletePostAsync(default!) as NoContentResult;

        // Assert
        deleteResponse!.Should().NotBeNull();
    }

    [Fact]
    public async Task DeletePostAsync_GivenNotFound_ReturnsNotFound(){
        // Arrange
        var postServiceSubstitute = Substitute.For<IPostsService>();
        postServiceSubstitute.DeletePostAsync(Arg.Any<int>()).ThrowsAsync(new KeyNotFoundException());

        // Act        
        PostsController postsController = new(postServiceSubstitute);
        var updateResponse = await postsController.DeletePostAsync(default!) as NotFoundResult;

        // Assert
        updateResponse!.Should().NotBeNull();
    }

    [Fact]
    public async Task UpdatePostAsync_GivenValidPost_ReturnsNoContent(){
        // Arrange
        var postServiceSubstitute = Substitute.For<IPostsService>();
        postServiceSubstitute.UpdatePostAsync(Arg.Any<UpdatePostDto>()).Returns(Task.CompletedTask);

        // Act        
        PostsController postsController = new(postServiceSubstitute);
        var updateResponse = await postsController.UpdatePostAsync(default!) as NoContentResult;

        // Assert
        updateResponse!.Should().NotBeNull();
    }

    [Fact]
    public async Task UpdatePostAsync_GivenNotFound_ReturnsNotFound(){
        // Arrange
        var postServiceSubstitute = Substitute.For<IPostsService>();
        postServiceSubstitute.UpdatePostAsync(Arg.Any<UpdatePostDto>()).ThrowsAsync(new KeyNotFoundException());

        // Act        
        PostsController postsController = new(postServiceSubstitute);
        var updateResponse = await postsController.UpdatePostAsync(default!) as NotFoundResult;

        // Assert
        updateResponse!.Should().NotBeNull();
    }
}