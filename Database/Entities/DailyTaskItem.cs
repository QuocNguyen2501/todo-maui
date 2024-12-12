namespace Todo.Database.Entities;

public class DailyTaskItem : BaseEntity
{
    public int UserId { get; set; }
    public string DailyTask { get; set; } = default!;
    public bool IsCompleted { get; set; }
}
