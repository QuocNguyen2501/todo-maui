using Todo.Database.Entities;

namespace Todo.Database.Repositories
{
    public interface IRepository<T> where T : BaseEntity,new()
    {
        Task<List<T>> GetItemsAsync();
        Task<T> GetItemAsync(int id);
        Task<int> SaveItemAsync(T item);
        Task<int> DeleteItemAsync(T item);
    }
}

