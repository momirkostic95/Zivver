using Posts.Repository.Model;

namespace Posts.Repository.Interface;

public interface IPostRepository
{
    Task<IEnumerable<Post>?> GetPosts();
}
