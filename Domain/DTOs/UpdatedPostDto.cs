namespace Domain.DTOs;

public class UpdatedPostDto
{

	/*why not innnit?*/
    public int Id { get; }
    public int? OwnerId { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }

    public UpdatedPostDto(int id)
    {
        Id = id;
    }
}
