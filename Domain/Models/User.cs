namespace Domain.Models;

/*
public class MyList
{
    public List<User>? Users { get; set; }
}
*/

public class User
{
	public User(string? username, string? password, string loggedIn)
	{
		Username = username;
		Password = password;
		LoggedIn = loggedIn;
	}

	public User()
	{

	}

	public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string LoggedIn { get; set; }
}
