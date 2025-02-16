using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Todo.Models;

public class RegisterModel: ObservableValidator
{
    private string username;
    private string email;
    private string password;
    private string confirmPassword;


    [Required]
    [MaxLength(50)]
    public string Name 
    { 
        get => username;
        set => SetProperty(ref username, value, true); 
    }

    [Required]
    [MaxLength(50)]
    public string Email 
    { 
        get => email; 
        set => SetProperty(ref email,value,true); 
    }

    [Required]
    [MaxLength(50)]
    public string Password 
    { 
        get => password; 
        set => SetProperty(ref password,value,true); 
    }

    [Required]
    [MaxLength(50)]
    [Compare("Password")]
    public string ConfirmPassword 
    { 
        get => confirmPassword; 
        set => SetProperty(ref confirmPassword,value,true); 
    }
}
