using Zivver.Repository.Model;

namespace Zivver.Service.Interface;

public interface IPostService
{
    Task<IEnumerable<Post>?> GetPosts();
}
