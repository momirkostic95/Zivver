using Posts.Repository.Model;

namespace Posts.Service.Interface;

public interface IPostService
{
    Task<IEnumerable<Post>?> GetPosts();
}
