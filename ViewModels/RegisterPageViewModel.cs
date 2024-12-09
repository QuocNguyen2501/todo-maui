using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Todo.Models;
using Todo.Pages;

namespace Todo.ViewModels;

public partial class RegisterPageViewModel:BaseViewModel
{
    public RegisterModel RegisterModel;

    public RegisterPageViewModel()
    {
        RegisterModel = new RegisterModel();
    }


    [RelayCommand]
    async Task GotoLoginPageAsync()
    {
        await Shell.Current.GoToAsync($"{nameof(LoginPage)}", true);
    }

    [RelayCommand]
    async Task ValidateConfirmPasswordCommand()
    {
        if (RegisterModel.ConfirmPassword != RegisterModel.Password)
        {
            await Shell.Current.DisplayAlert("Error","Confirm password doesn't match with password","Ok");
        }
    }




}
