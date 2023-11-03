namespace Domain.DTOs;

public class PostClearDto
{
	public string Title { get; }
	public string Body { get; }
    public int Id { get; set; }
    public string? OwnerName { get; }
    public PostClearDto(int id, string? ownerName, string title, string body)
    {
        Id = id;
        OwnerName = ownerName;
        Title = title;
        Body = body;
    }
}
