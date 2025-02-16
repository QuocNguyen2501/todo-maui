using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Todo.Database.Repositories;
using Todo.Models;
using Todo.Pages;

namespace Todo.ViewModels;

public partial class LoginPageViewModel:BaseViewModel
{
    private LoginModel loginModel;
    private readonly FirebaseAuthClient _authClient;

    public LoginModel LoginModel
    {
        get => loginModel;
        set => SetProperty(ref loginModel, value);
    }

    public LoginPageViewModel(
        FirebaseAuthClient authClient
        )
    {
        LoginModel = new LoginModel();
        _authClient = authClient;
    }


    [RelayCommand]
    async Task GotoRegisterPageAsync()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    async Task GotoHomePageAsync()
    {
        if (LoginModel.HasErrors)
        {
            var validationErrors = LoginModel.GetErrors().ToArray();
            for (int i = 0; i < validationErrors.Count(); i++)
            {
                await Shell.Current.DisplayAlert("Error", validationErrors[i].ToString(), "Ok");
            }
            return;
        }
       
        await _authClient.SignInWithEmailAndPasswordAsync(LoginModel.Email,LoginModel.Password);
        var user = _authClient.User;
        if(user == null){
            await Shell.Current.DisplayAlert("Error", "Email/Password is incorrect", "Ok");
            return;
        }

        await Shell.Current.GoToAsync($"{nameof(HomePage)}",
            true,
            new Dictionary<string, object>()
            {
                { "UserInfo", 
                    new CurrentUserModel {
                        UserId = user.Uid,
                        FullName =user.Info.DisplayName
                    } 
                }
            }
        );
    }
}
