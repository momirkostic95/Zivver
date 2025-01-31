using System.Net.Http;
using System.Text.Json;
using Zivver.Repository.Interface;
using Zivver.Repository.Model;

namespace Zivver.Repository.Repository;

public class PostRepository : IPostRepository
{
    private const string URL = "https://jsonplaceholder.typicode.com";
    public PostRepository()
    {
    }
    /// <summary>
    /// Fetch posts from jsonplaceholder API
    /// </summary>
    /// <returns>Returns list of posts</returns>
    public async Task<IEnumerable<Post>?> GetPosts()
    {
        using var client = new HttpClient();
        var url = new Uri($"{URL}/posts");
        using var response = await client.GetAsync(url);
        var data = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Post[]>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}
