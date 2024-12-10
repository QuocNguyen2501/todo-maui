using System.Timers;
using Todo.ViewModels;

namespace Todo.Pages;

public partial class HomePage : ContentPage
{
    private System.Timers.Timer timer;
    public HomePage(HomePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

        timer = new System.Timers.Timer();
        timer.Interval = 1000;
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
    }

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        // Calculate angles for hour and minute hands
        double hourAngle = (DateTime.Now.Hour % 12 + DateTime.Now.Minute / 60.0) * 30;
        double minuteAngle = DateTime.Now.Minute * 6;
        double secondAngle = DateTime.Now.Second * 6;

        // Update hand rotations
        hourHand.Rotation = hourAngle;
        minuteHand.Rotation = minuteAngle;
        secondHand.Rotation = secondAngle;
    }
}