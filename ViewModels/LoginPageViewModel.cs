using CommunityToolkit.Mvvm.Input;
using Todo.Database.Entities;
using Todo.Database.Repositories;
using Todo.Models;
using Todo.Pages;

namespace Todo.ViewModels;

public partial class LoginPageViewModel:BaseViewModel
{
    private LoginModel loginModel;

    private IRepository<User> _userRepository;

    public LoginModel LoginModel
    {
        get => loginModel;
        set => SetProperty(ref loginModel, value);
    }

    public LoginPageViewModel(IRepository<User> userRepository)
    {
        LoginModel = new LoginModel();
        _userRepository = userRepository;
    }


    [RelayCommand]
    async Task GotoRegisterPageAsync()
    {
        await Shell.Current.GoToAsync($"{nameof(RegisterPage)}", true);
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
        var allUsers = (await _userRepository.GetItemsAsync());
        var user = allUsers.FirstOrDefault(f => f.Email == LoginModel.Email && f.Password == LoginModel.Password);
        if (user == null)
        {
            await Shell.Current.DisplayAlert("Error", "Email/Password is incorrect", "Ok");
            return;
        }

        await Shell.Current.GoToAsync($"{nameof(HomePage)}",
            true,
            new Dictionary<string, object>()
            {
                { "UserInfo", 
                    new CurrentUserModel {
                        UserId = user.Id,
                        FullName =user.FullName
                    } 
                }
            }
        );
    }
}
