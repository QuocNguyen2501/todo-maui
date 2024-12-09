using Todo.ViewModels;

namespace Todo.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}