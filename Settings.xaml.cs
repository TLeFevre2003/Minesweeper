namespace MauiApp1;
using Microsoft.Maui.Controls;


public partial class SettingsPage : ContentPage
{
    int rows = 0;
    int columns = 0;
    int bombs = 0;
    public SettingsPage()
    {
        InitializeComponent();
    }

    private async void StartGame_Clicked(object sender, EventArgs e)
    {
        // Retrieve the values entered by the user from the Entry controls
        rows = Convert.ToInt32(RowsEntry.Text);
        columns = Convert.ToInt32(ColumnsEntry.Text);
        bombs = Convert.ToInt32(BombsEntry.Text);

        // Pass the selected board size to the game page or create the game here
        // For example, you can navigate to a new page and pass the values as parameters:
        // Navigation.PushAsync(new GamePage(rows, columns));

        await Navigation.PushAsync(new GamePage(rows, columns, bombs));
    }
}

