using CommunityToolkit.Mvvm.Input;
using Todo.Database.Entities;
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

    private IRepository<User> _userRepository;

    public RegisterPageViewModel(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
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
        await _userRepository.SaveItemAsync(new User
        {
            FullName = RegisterModel.Name,
            Email = RegisterModel.Email,
            Password = RegisterModel.Password,
            CreatedDate = DateTime.UtcNow
        });
        await Shell.Current.GoToAsync($"{nameof(LoginPage)}", true);
    }


}
