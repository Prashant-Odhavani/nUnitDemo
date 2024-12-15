using nUnitDemo.Api.Models;

namespace nUnitDemo.Api.Services.Interfaces
{
    public interface IPostService
    {
        Task<Post> CreatePostAsync(Post post);
        Task DeletePostAsync(int id);
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);
        Task<Post?> GetPostByIdAsync(int id);
        Task<IEnumerable<Post>?> GetPostsAsync();
        Task PatchPostAsync(int id, object patchData);
        Task UpdatePostAsync(int id, Post post);
    }
}
