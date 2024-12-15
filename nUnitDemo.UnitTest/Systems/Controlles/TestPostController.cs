using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using nUnitDemo.Api.Controllers;
using nUnitDemo.Api.Models;
using nUnitDemo.Api.Services.Interfaces;

namespace nUnitDemo.UnitTest.Systems.Controlles
{
    [TestFixture]
    public class TestPostController
    {
        private Mock<IPostService> _mockPostService;
        private PostController _postController;

        [SetUp]
        public void SetUp()
        {
            _mockPostService = new Mock<IPostService>();
            _postController = new PostController(_mockPostService.Object);
        }

        [Test]
        public async Task GetPosts_ShouldReturnOkWithPosts()
        {
            // Arrange
            var posts = new List<Post> { new Post { Id = 1, Title = "Test Post", Body = "Test Body" } };
            _mockPostService.Setup(service => service.GetPostsAsync()).ReturnsAsync(posts);

            // Act
            var result = await _postController.GetPosts();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(posts);
        }

        [Test]
        public async Task GetPostById_ShouldReturnOkWithPost()
        {
            // Arrange
            var post = new Post { Id = 1, Title = "Test Post", Body = "Test Body" };
            _mockPostService.Setup(service => service.GetPostByIdAsync(1)).ReturnsAsync(post);

            // Act
            var result = await _postController.GetPostById(1);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(post);
        }

        [Test]
        public async Task GetComments_ShouldReturnOkWithComments()
        {
            // Arrange
            var comments = new List<Comment> { new Comment { Id = 1, PostId = 1, Body = "Test Comment" } };
            _mockPostService.Setup(service => service.GetCommentsByPostIdAsync(1)).ReturnsAsync(comments);

            // Act
            var result = await _postController.GetComments(1);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(comments);
        }

        [Test]
        public async Task CreatePost_ShouldReturnCreatedAtAction()
        {
            // Arrange
            var post = new Post { Title = "New Post", Body = "New Body" };
            var createdPost = new Post { Id = 1, Title = "New Post", Body = "New Body" };
            _mockPostService.Setup(service => service.CreatePostAsync(post)).ReturnsAsync(createdPost);

            // Act
            var result = await _postController.CreatePost(post);

            // Assert
            result.Should().BeOfType<CreatedAtActionResult>();
            var createdResult = result as CreatedAtActionResult;
            createdResult.Value.Should().BeEquivalentTo(createdPost);
            createdResult.ActionName.Should().Be(nameof(PostController.GetPostById));
        }

        [Test]
        public async Task UpdatePost_ShouldReturnNoContent()
        {
            // Arrange
            var post = new Post { Title = "Updated Post", Body = "Updated Body" };
            _mockPostService.Setup(service => service.UpdatePostAsync(1, post)).Returns(Task.CompletedTask);

            // Act
            var result = await _postController.UpdatePost(1, post);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Test]
        public async Task PatchPost_ShouldReturnNoContent()
        {
            // Arrange
            var patchData = new { Title = "Updated Title" };
            _mockPostService.Setup(service => service.PatchPostAsync(1, patchData)).Returns(Task.CompletedTask);

            // Act
            var result = await _postController.PatchPost(1, patchData);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Test]
        public async Task DeletePost_ShouldReturnNoContent()
        {
            // Arrange
            _mockPostService.Setup(service => service.DeletePostAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _postController.DeletePost(1);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }
    }
}
