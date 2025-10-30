namespace TariasTS3.Views;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}

    private async void OnVLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new vLogin());
    }

    private async void OnVista2Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Vista1());
    }
}
