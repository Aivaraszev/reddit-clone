﻿using Application.DaoInterfaces;
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
}