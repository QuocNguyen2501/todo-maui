using CommunityToolkit.Mvvm.Input;
using Todo.Pages;

namespace Todo.ViewModels;

public partial class LoginPageViewModel:BaseViewModel
{

    [RelayCommand]
    async Task GotoRegisterPageAsync()
    {
        await Shell.Current.GoToAsync($"{nameof(RegisterPage)}", true);
    }

    [RelayCommand]
    async Task GotoHomePageAsync()
    {
        await Shell.Current.GoToAsync($"{nameof(HomePage)}", true);
    }
}
