namespace Domain.DTOs;

public class SearchUserParamsDto
{
    public String? UsernameContains { get; }




    /*shouldnt usernameContains be != null??*/

    public SearchUserParamsDto(string? usernameContains)
    {
        UsernameContains = usernameContains;
    }
}
