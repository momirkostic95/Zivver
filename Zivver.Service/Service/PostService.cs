using Zivver.Repository.Interface;
using Zivver.Repository.Model;
using Zivver.Service.Interface;

namespace Zivver.Service.Service;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    public async Task<IEnumerable<Post>?> GetPosts()
    {
        try
        {
            return await _postRepository.GetPosts();
        }
        catch (Exception)
        {
            throw;
        }
        
    }
}
