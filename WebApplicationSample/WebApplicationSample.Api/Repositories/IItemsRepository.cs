using WebApplicationSample.Api.Models;

namespace WebApplicationSample.Api.Repositories;

public interface IItemsRepository
{
    Task<IEnumerable<Item?>> GetItemsAsync();
    Task<Item?> GetItemAsync(Guid id);
    Task CreateItemAsync(Item item);
    Task UpdateItemAsync(Item item);
    Task DeleteItemAsync(Guid id);

}