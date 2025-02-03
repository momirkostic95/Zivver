using Posts.Repository.Interface;
using Posts.Repository.Model;
using Posts.Service.Interface;

namespace Posts.Service.Service;

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
