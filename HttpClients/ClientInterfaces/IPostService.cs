using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<IEnumerable<Post>> GetAsync();
    Task<Post> GetByIdAsync(int id);
    Task CreateAsync(PostCreationDto dto);
}