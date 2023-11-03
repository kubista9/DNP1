using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace FileData.DAOs;

public class UserFileDao : IUserDao
{
    private readonly FileContext _context;

    public UserFileDao(FileContext context)
    {
        _context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (_context.Users.Any())
        {
            userId = _context.Users.Max(u => u.Id);
            userId++;
        }
        user.Id = userId;
        _context.Users.Add(user);
        _context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParamsDto searchParams)
    {
	    IEnumerable<User> users = _context.Users.AsEnumerable();
	    if (searchParams.UsernameContains != null)
	    {
		    users = _context.Users.Where(user => user.Username.Contains(searchParams.UsernameContains, StringComparison.OrdinalIgnoreCase));
	    }

	    return Task.FromResult(users);
    }

    public Task<User?> GetByUsernameAsync(string? userName)
    {
        User? existing = _context.Users.FirstOrDefault(user => user.Username.Equals(userName, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        User? existing = _context.Users.FirstOrDefault(user => user.Id == id);
        return Task.FromResult(existing);
    }
}
