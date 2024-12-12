using SQLite;

namespace Todo.Database.Entities
{
	public class BaseEntity
	{
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; } = default!;
        public DateTime CreatedDate { get; set; } = default!;
    }
}

