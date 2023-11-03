using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao _userDao;

    public UserLogic(IUserDao userDao)
    {
        _userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? oldUser = await _userDao.GetByUsernameAsync(dto.Username);
        if (oldUser != null)
            throw new Exception("Choose other username");

        ValidateData(dto);
        User toCreate = new User
        {
            Username = dto.Username,
            Password = dto.Password
        };

        User newUser = await _userDao.CreateAsync(toCreate);
        return newUser;
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParamsDto searchParams)
    {
        return _userDao.GetAsync(searchParams);
    }

    private static void ValidateData(UserCreationDto userToCreate)
    {
        string? userName = userToCreate.Username;

        if (userName.Length < 3)
            throw new Exception("Username must bet at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }
}
