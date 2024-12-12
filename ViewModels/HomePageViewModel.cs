using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Todo.Database.Entities;
using Todo.Database.Repositories;
using Todo.Models;

namespace Todo.ViewModels;

[QueryProperty("UserInfo", "UserInfo")]
public partial class HomePageViewModel:BaseViewModel
{
    private DailyTaskModel dailyTaskModel;
    public DailyTaskModel DailyTaskModel
    {
        get => dailyTaskModel;
        set => SetProperty(ref dailyTaskModel, value);
    }

    [ObservableProperty]
    public string greeting;

    [ObservableProperty]
    public CurrentUserModel userInfo;

    [ObservableProperty]
    public string welcome;

    public ObservableCollection<DailyTaskModel> DailyTasks { get; } = new();


    private IRepository<DailyTaskItem> _dailyTaskRepository;
    public HomePageViewModel(IRepository<DailyTaskItem> dailyTaskRepository)
    {
        _dailyTaskRepository = dailyTaskRepository;
        DailyTaskModel = new DailyTaskModel();
    }

    [RelayCommand]
    public async Task AppearingAsync()
    {
        await LoadDailyTasksAsync();
        Greeting = GetGreeting();
        Welcome = $"Welcome {UserInfo.FullName}";
    }
   

    [RelayCommand]
    public async Task AddDailyTaskAsync()
    {
        if (string.IsNullOrEmpty(DailyTaskModel.DailyTask.Trim()))
            return;

        var item = new DailyTaskItem
        {
            CreatedDate = DateTime.UtcNow,
            DailyTask = DailyTaskModel.DailyTask,
            IsCompleted = false,
            UserId = UserInfo.UserId
        };

        await _dailyTaskRepository.SaveItemAsync(item);
        DailyTaskModel.DailyTask = "";

        DailyTasks.Add(new DailyTaskModel
        {
            Id = item.Id,
            DailyTask = item.DailyTask,
            IsCompleted = item.IsCompleted,
        });
    }

    [RelayCommand]
    public async Task FinishTaskAsync(int dailyId)
    {
        var item = await _dailyTaskRepository.GetItemAsync(dailyId);
        if (item is null)
            return;

        item.IsCompleted = !item.IsCompleted;
        await _dailyTaskRepository.SaveItemAsync(item);

        DailyTasks.First(f=>f.Id== dailyId).IsCompleted = item.IsCompleted;
    }

    private string GetGreeting()
    {
        var hour = DateTime.Now.Hour;
        if (hour < 5 || hour > 23)
        {
            return "Good night";
        }
        else {
            if (hour >= 17)
            {
                return "Good evening";
            }
            else
            {
                if (hour >= 12)
                {
                    return "Good afternoon";
                }
                else
                {
                    return "Good morning";
                }
            }
        }

    }

    private async Task LoadDailyTasksAsync()
    {
        if (DailyTasks.Count != 0)
        {
            DailyTasks.Clear();
        }
        foreach (var task in (await _dailyTaskRepository.GetItemsAsync()).Where(w => w.UserId == UserInfo.UserId).ToList())
        {
            DailyTasks.Add(new DailyTaskModel
            {
                Id = task.Id,
                DailyTask = task.DailyTask,
                IsCompleted = task.IsCompleted,
            });
        }
    }
}
