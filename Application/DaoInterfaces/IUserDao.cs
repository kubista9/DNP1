using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    public Task<IEnumerable<User>> GetAsync(SearchUserParamsDto searchParams);
    Task<User?> GetByIdAsync(int dtoOwnerId);
    Task<User?> GetByUsernameAsync(string? username);


}
