using Todo.ViewModels;

namespace Todo.Pages;

public partial class WelcomePage : ContentPage
{
    public WelcomePage(WelcomePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}