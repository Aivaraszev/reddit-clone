namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; }
    public string Body { get; }
    public User Poster { get; }

    public Post(string title, string body, User poster)
    {
        Title = title;
        Body = body;
        Poster = poster;
    }
}