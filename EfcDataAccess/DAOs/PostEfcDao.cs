using Application.DaoInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly PostContext _context;

    public PostEfcDao(PostContext context)
    {
        _context = context;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        var newPost = await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        IQueryable<Post> query = _context.Posts.Include(post => post.Poster).AsQueryable();
        var result = await query.ToListAsync();
        return result;
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        var post = await _context.Posts.Include(post => post.Poster).SingleOrDefaultAsync(p => p.Id == id);
        return post;
    }
}