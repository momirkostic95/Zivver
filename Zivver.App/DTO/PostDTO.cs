namespace Zivver.App.DTO;

public class PostDTO
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string DisplayId()
    {
        return $"Id: {Id}";
    }
    public string DisplayUserId()
    {
        return $"User Id: {UserId}";
    }
}
