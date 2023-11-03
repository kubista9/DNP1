
using Domain.DTOs;
using Domain.Models;

using Application.DaoInterfaces;

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
        if (_context.Posts != null && _context.Posts.Any())
        {
            id = _context.Posts.Max(post => post.Id);
            id++;
        }

        post.Id = id;
        if (_context.Posts != null) _context.Posts.Add(post);
        _context.SaveChanges();
        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParamsDto searchParams)
    {
        IEnumerable<Post> posts = _context.Posts.AsEnumerable();
        if (!string.IsNullOrEmpty(searchParams.Username))
        {
            posts = _context.Posts.Where(post => post.Owner.Username.Equals(searchParams.Username, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParams.UserId != null)
        {
            posts = posts.Where(psot => psot.Owner.Id == searchParams.UserId);
        }

        if (!string.IsNullOrEmpty(searchParams.TitleContains))
        {
            posts = posts.Where(post => post.Title.Contains(searchParams.TitleContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(posts);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        Post? existing = _context.Posts.FirstOrDefault(p =>
            p.Id == id
        );
        return Task.FromResult(existing);
    }

    public Task UpdateAsync(Post toUpdate)
    {
        Post? existing = _context.Posts.FirstOrDefault(post => post.Id == toUpdate.Id);
        if (existing == null)
        {
            throw new Exception($"PostId {toUpdate.Id} does not exist!");
        }
        _context.Posts.Remove(existing);
        _context.Posts.Add(toUpdate);
        _context.SaveChanges();
        return Task.CompletedTask;
    }
}
