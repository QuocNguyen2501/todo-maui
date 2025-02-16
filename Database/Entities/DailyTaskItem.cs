namespace Todo.Database.Entities;

public class DailyTaskItem : BaseEntity
{
    public string UserId { get; set; } = default!;
    public string DailyTask { get; set; } = default!;
    public bool IsCompleted { get; set; }
}
