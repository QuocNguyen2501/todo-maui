using SQLite;
using Todo.Database.Entities;

namespace Todo.Database;

public class TodoDatabase
{
	private SQLiteAsyncConnection _database;

	public async Task<SQLiteAsyncConnection> getDbAsync()
	{
        if (_database is not null)
            return _database;

        _database = new SQLiteAsyncConnection(DbConstants.DatabasePath, DbConstants.Flags);
        await _database.CreateTableAsync<TodoItem>();
        await _database.CreateTableAsync<User>();
        return _database;
    }


}

