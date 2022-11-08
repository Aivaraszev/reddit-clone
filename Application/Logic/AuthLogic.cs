using System.ComponentModel.DataAnnotations;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.Models;

namespace Application.Logic;

public class AuthLogic : IAuthLogic
{
    private readonly IUserDao _userDao;

    public AuthLogic(IUserDao userDao)
    {
        _userDao = userDao;
    }

    public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = await _userDao.GetByUsername(username);

        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }
}