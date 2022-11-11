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
        User? existing = await _userDao.GetByUsername(dto.Username);
        if (existing != null)
            throw new Exception("Username is already in use");

        User toCreate = new User
        {
            Username = dto.Username,
            Password = dto.Password,
            Role = dto.Role
        };
        User created = await _userDao.CreateAsync(toCreate);
        return created;
    }
}