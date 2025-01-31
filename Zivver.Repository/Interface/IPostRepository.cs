using Zivver.Repository.Model;

namespace Zivver.Repository.Interface;

public interface IPostRepository
{
    Task<IEnumerable<Post>?> GetPosts();
}
