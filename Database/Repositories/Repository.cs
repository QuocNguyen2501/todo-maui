using Todo.Database.Entities;

namespace Todo.Database.Repositories;

public class Repository<T> : IRepository<T> where T: BaseEntity, new()
{
    public readonly TodoDatabase TodoDatabase;

    public Repository(TodoDatabase _todoDatabase)
    {
        TodoDatabase = _todoDatabase;
    }

    public async Task<int> DeleteItemAsync(T item)
    {
        var db = await TodoDatabase.getDbAsync();
        return await db.DeleteAsync(item);
    }

    public async Task<T> GetItemAsync(int id)
    {
        var db = await TodoDatabase.getDbAsync();
        return await db.Table<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<T>> GetItemsAsync()
    {
        var db = await TodoDatabase.getDbAsync();
        return await db.Table<T>().ToListAsync();
    }

    public async Task<int> SaveItemAsync(T item)
    {
        var db = await TodoDatabase.getDbAsync();
        if (item.Id != 0)
            return await db.UpdateAsync(item);
        else
            return await db.InsertAsync(item);
    }
}

