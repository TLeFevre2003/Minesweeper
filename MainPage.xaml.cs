

using static System.Reflection.Metadata.BlobBuilder;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }


    private async void OnGoToSettingsPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage());
    }
    private async void EasyOnClick(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new GamePage(8, 10, 10));
    }
    private async void MediumOnClick(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new GamePage(14, 18, 40));
    }
    private async void HardOnClick(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new GamePage(20, 24, 99));
    }


}
