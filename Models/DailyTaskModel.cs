using CommunityToolkit.Mvvm.ComponentModel;

namespace Todo.Models;

public class DailyTaskModel : ObservableValidator
{
    private int id;
    private string dailyTask;
    private bool isCompleted;

    public int Id 
    { 
        get => id; 
        set => SetProperty(ref id, value, true); 
    }

    public string DailyTask 
    { 
        get => dailyTask; 
        set => SetProperty(ref dailyTask,value,true); 
    }
    public bool IsCompleted 
    { 
        get => isCompleted; 
        set => SetProperty(ref isCompleted, value);
    }
}
