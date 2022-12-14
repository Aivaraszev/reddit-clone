using Application.DaoInterfaces;
using Domain.Models;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext _context;

    public PostFileDao(FileContext context)
    {
        _context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;
        if (_context.Posts.Any())
        {
            id = _context.Posts.Max(p => p.Id);
            id++;
        }

        post.Id = id;

        _context.Posts.Add(post);
        _context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync()
    {
        var posts = _context.Posts.AsEnumerable();
        return Task.FromResult(posts);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        var existing = _context.Posts.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(existing);
    }
}