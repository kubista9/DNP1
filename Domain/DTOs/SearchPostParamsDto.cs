namespace Domain.DTOs;

public class SearchPostParamsDto
{

	/*/Check in the source code/*/
    public string? Username { get; }
    public int? UserId { get; }
    public string? TitleContains { get; }

    public SearchPostParamsDto(string? username, int? userId, string titleContains)
    {
        Username = username;
        UserId = userId;
        TitleContains = titleContains;
    }
}
