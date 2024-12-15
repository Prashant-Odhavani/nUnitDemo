using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nUnitDemo.Api.Models;
using nUnitDemo.Api.Services.Interfaces;

namespace nUnitDemo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController(IPostService postService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPosts()
    {
        var posts = await postService.GetPostsAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        var post = await postService.GetPostByIdAsync(id);
        if (post == null)
            return NotFound();
        return Ok(post);
    }

    [HttpGet("{id}/comments")]
    public async Task<IActionResult> GetComments(int id)
    {
        var comments = await postService.GetCommentsByPostIdAsync(id);
        return Ok(comments);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(Post post)
    {
        var createdPost = await postService.CreatePostAsync(post);
        return CreatedAtAction(nameof(GetPostById), new { id = createdPost.Id }, createdPost);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, Post post)
    {
        await postService.UpdatePostAsync(id, post);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchPost(int id, object patchData)
    {
        await postService.PatchPostAsync(id, patchData);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        await postService.DeletePostAsync(id);
        return NoContent();
    }
}

