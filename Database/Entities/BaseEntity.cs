namespace Todo.Database.Entities
{
	public class BaseEntity
	{
        public int Id { get; set; } = default!;
        public DateTime CreatedDate { get; set; } = default!;
    }
}

