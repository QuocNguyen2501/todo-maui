
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Todo.Models;

public class LoginModel : ObservableValidator
{
	private string email;
	private string password;

    [Required]
    [MaxLength(50)]
    public string Email
	{
		get => email;
		set => SetProperty(ref email, value, true);
	}

    [Required]
    [MaxLength(50)]
    public string Password
	{
		get => password;
		set => SetProperty(ref password, value, true);
	}
}

