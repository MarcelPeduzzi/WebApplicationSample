﻿using WebApplicationSample.Models;

namespace WebApplicationSample.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item?> _items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Tetris", Price = 5, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Fifa 2022", Price = 50, CreatedDate = DateTimeOffset.UtcNow }
        };

        public async Task<IEnumerable<Item?>> GetItemsAsync()
        {
            return await Task.FromResult(_items);
        }

        public async Task<Item?> GetItemAsync(Guid id)
        {
            var item = _items.SingleOrDefault(i => i != null && i.Id == id);
            return await Task.FromResult(item);
        }

        public async Task CreateItemAsync(Item item)
        {
            _items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == item.Id);
            _items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == id);
            _items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
