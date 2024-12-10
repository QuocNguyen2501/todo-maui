namespace Todo.Database.Entities;

public class TodoItem:BaseEntity
{
	public string Todo { get; set; } = default!;
	public bool IsFinish { get; set; } = default!;
}

