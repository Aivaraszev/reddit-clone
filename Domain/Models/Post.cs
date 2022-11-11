namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; init; }
    public string Body { get; init; }
    public User Poster { get; init; }


}