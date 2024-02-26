namespace UniAPP.Views;

public partial class UniViews : ContentView
{
	public UniViews(string uniname, string uniwebsite)
	{
		InitializeComponent();
		UniName.Text = uniname;
		UniWebsit.Text = uniwebsite;
	}
}