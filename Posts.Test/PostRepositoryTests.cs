using Moq;
using Posts.Repository.Interface;
using Posts.Repository.Model;

namespace Posts.Test;

public class PostRepositoryTests
{
    private readonly Mock<IPostRepository> _mockPostRepository;

    public PostRepositoryTests()
    {
        _mockPostRepository = new Mock<IPostRepository>();
    }

    [Fact]
    public async Task GetPostAsync()
    {
        var expectedProduct = new List<Post>  
        { 
            new Post {Id = 1, UserId = 1, Title = "Test title 1", Body = "Test body 1" },
            new Post {Id = 2, UserId = 1, Title = "Test title 2", Body = "Test body 2" }
        };
        _mockPostRepository.Setup(repo => repo.GetPosts()).ReturnsAsync(expectedProduct);

        var result = await _mockPostRepository.Object.GetPosts();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Equal(expectedProduct, result);
    }
}
