using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao _postDao;
    private readonly IUserDao _userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        _postDao = postDao;
        _userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await _userDao.GetByUsername(dto.PosterUsername);
        if (user == null)
        {
            throw new Exception($"Poster with username {dto.PosterUsername} does not exist");
        }

        Post post = new Post(dto.Title, dto.Body, user);
        ValidatePost(post);
        Post created = await _postDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync()
    {
        return _postDao.GetAsync();
    }

    private void ValidatePost(Post post)
    {
    }
}