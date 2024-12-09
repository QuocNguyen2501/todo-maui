using CommunityToolkit.Mvvm.Input;
using Todo.Pages;

namespace Todo.ViewModels;
public partial class WelcomePageViewModel: BaseViewModel
{
    [RelayCommand]
    async Task GotoRegisterPageAsync()
    {
        await Shell.Current.GoToAsync($"{nameof(RegisterPage)}",true);
    }
}
