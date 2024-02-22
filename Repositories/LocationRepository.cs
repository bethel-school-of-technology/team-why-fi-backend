using backend.Migrations;
using backend.Models;


namespace backend.Repositories;

public class LocationRepository : ILocationRepository 
{
    private readonly LocationDbContext _context;

    public LocationRepository(LocationDbContext context)
    {
        _context = context;
    }

    public Post CreatePost(Post newPost)
    {
        _context.Post.Add(newPost);
        _context.SaveChanges();
        return newPost;
    }

    public void DeletePostById(int PostId)
    {
        var post = _context.Post.Find(PostId);
        if (post != null) {
            _context.Post.Remove(post); 
            _context.SaveChanges(); 
        }
    }

    public IEnumerable<Post> GetAllPost()
    {
        return _context.Post.ToList();
    }

    public Post? GetPostById(int PostId)
    {
        return _context.Post.SingleOrDefault(c => c.PostId == PostId);
    }

    public Post? UpdatePost(Post newPost)
    {
        var originalPost = _context.Post.Find(newPost.PostId);
        if (originalPost != null) {
            originalPost.Message = newPost.Message;
            _context.SaveChanges();
        }
        return originalPost;
    }
}