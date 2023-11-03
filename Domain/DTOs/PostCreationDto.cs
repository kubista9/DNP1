namespace Domain.DTOs;

public class PostCreationDto
{

	public string Title { get;}
	public string Body { get; }
    public int OwnerId { get; }


    public PostCreationDto(int ownerId, string title, string body)
    {
        OwnerId = ownerId;
        Title = title;
        Body = body;
    }
}
