using nUnitDemo.Api.Models;
using nUnitDemo.Api.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace nUnitDemo.Api.Services;

public class PostService(HttpClient httpClient) : IPostService
{
    public async Task<IEnumerable<Post>?> GetPostsAsync()
    {
        var response = await httpClient.GetAsync("posts");
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<Post>>(json);
    }

    public async Task<Post?> GetPostByIdAsync(int id)
    {
        var response = await httpClient.GetAsync($"posts/{id}");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Post?>(json);
    }

    public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId)
    {
        var response = await httpClient.GetAsync($"comments?postId={postId}");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<Comment>>(json);
    }

    public async Task<Post> CreatePostAsync(Post post)
    {
        var content = new StringContent(JsonSerializer.Serialize(post), Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("posts", content);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Post>(json);
    }

    public async Task UpdatePostAsync(int id, Post post)
    {
        var content = new StringContent(JsonSerializer.Serialize(post), Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync($"posts/{id}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task PatchPostAsync(int id, object patchData)
    {
        var content = new StringContent(JsonSerializer.Serialize(patchData), Encoding.UTF8, "application/json");
        var response = await httpClient.PatchAsync($"posts/{id}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeletePostAsync(int id)
    {
        var response = await httpClient.DeleteAsync($"posts/{id}");
        response.EnsureSuccessStatusCode();
    }
}

