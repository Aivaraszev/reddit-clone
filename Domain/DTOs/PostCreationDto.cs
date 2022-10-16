namespace Domain.DTOs;

public class PostCreationDto
{
    public string PosterUsername { get; }
    public string Title { get; }
    public string Body { get; }

    public PostCreationDto(string title, string body, string posterUsername)
    {
        Title = title;
        Body = body;
        PosterUsername = posterUsername;
    }
}