namespace Todo.Database.Entities;

public class User:BaseEntity
{
	public string FullName { get; set; } = default!;
	public string Email { get; set; } = default!;
	public string Password { get; set; } = default!;
}

