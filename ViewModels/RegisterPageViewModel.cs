using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Todo.Database.Repositories;
using Todo.Models;
using Todo.Pages;

namespace Todo.ViewModels;

public partial class RegisterPageViewModel:BaseViewModel
{
    private RegisterModel registerModel;
    public RegisterModel RegisterModel
    {
        get => registerModel;
        set => SetProperty(ref registerModel, value);
    }

    private readonly FirebaseAuthClient _authClient;
    public RegisterPageViewModel(
        IRepository<Database.Entities.User> userRepository,
        FirebaseAuthClient authClient)
    {
        _authClient = authClient;
        RegisterModel = new RegisterModel();
    }


    [RelayCommand]
    async Task GotoLoginPageAsync()
    {
        await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
    }

    [RelayCommand]
    async Task ValidateConfirmPasswordCommand()
    {
        if (RegisterModel.ConfirmPassword != RegisterModel.Password)
        {
            await Shell.Current.DisplayAlert("Error","Confirm password doesn't match with password","Ok");
        }
    }

    [RelayCommand]
    async Task RegisterAsync()
    {
        if (RegisterModel.HasErrors)
        {
            var validationErrors = registerModel.GetErrors().ToArray();
            for (int i = 0; i < validationErrors.Count(); i++)
            {
                await Shell.Current.DisplayAlert("Error", validationErrors[i].ToString(), "Ok");
            }
            return;
        }
        await _authClient.CreateUserWithEmailAndPasswordAsync(registerModel.Email,registerModel.Password,RegisterModel.Name);
        await Shell.Current.GoToAsync($"{nameof(LoginPage)}", true);
    }


}
