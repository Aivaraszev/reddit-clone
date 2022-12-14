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
        User? user = await _userDao.GetByUsername(dto.Username);
        if (user == null)
        {
            throw new Exception($"Poster with username {dto.Username} was not found");
        }

        Post post = new Post
        {
            Title = dto.Title,
            Body = dto.Body,
            Poster = user
        };
        ValidatePost(post);
        Post created = await _postDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync()
    {
        return _postDao.GetAsync();
    }

    public async Task<Post> GetByIdAsync(int id)
    {
        return await _postDao.GetByIdAsync(id) ?? throw new Exception($"Post with id {id} was not found");
    }

    private void ValidatePost(Post post)
    {
        if (string.IsNullOrEmpty(post.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(post.Body)) throw new Exception("Body cannot be empty.");
    }
}