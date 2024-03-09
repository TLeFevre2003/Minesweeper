namespace MauiApp1;

public partial class GamePage : ContentPage
{
    private Board _board;
    public int rows;
    public int columns;

    public GamePage(int x, int y, int bombs)
    {

        this.rows = x;
        this.columns = y;
        InitializeComponent();

        _board = new Board(this.rows,this.columns, bombs);

        // Call a method to create and add buttons to the grid
        PopulateGridWithButtons();
    }

    private void PopulateGridWithButtons()
    {
        // Define the number of rows and columns
        int numRows = rows;
        int numCols = columns;


        // Create rows and columns for the grid
        for (int i = 0; i < numRows; i++)
        {
            GameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        }

        for (int i = 0; i < numCols; i++)
        {
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
        }

        double buttonSize = Math.Min(GameGrid.Width / numCols, GameGrid.Height / numRows);


        // Loop to create and add buttons to the grid
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                // Create a new button
                Button button = new Button
                {
                    Text = _board.getButtonText(row, col), // Set button text to initial count
                    WidthRequest = 10, // Set button widthg
                    HeightRequest = 10, // Set button height
                    CornerRadius = 0, // Set button corners to be square
                    BorderColor = Colors.Black,
                    BorderWidth = 1,
                    BackgroundColor = Colors.LightGreen,
                    
                };


                // Add an event handler for button click event
                // Capture loop variables in local scope
                int currentRow = row;
                int currentCol = col;
                button.Clicked += (sender, e) =>
                {
                    _board.clicked(currentRow, currentCol);
                    // Increment the count for this button
                    //_board.incrementButton(currentRow,currentCol);

                    // Update the button text to display the new count
                    updateButtonText();
                };

                // Add the button to the grid
                GameGrid.Children.Add(button);

                // Set the row and column indices for the button
                Grid.SetRow(button, row);
                Grid.SetColumn(button, col);
            }
        }

    }
    private void updateButtonText()
    {
        foreach (View child in GameGrid.Children)
        {
            if (child is Button button)
            {
                // Get the row and column indices of the button
                int currentRow = Grid.GetRow(button);
                int currentCol = Grid.GetColumn(button);

                // Update the button text to display the new count
                button.Text = _board.getButtonText(currentRow, currentCol);
                if (_board.isShowing(currentRow,currentCol))
                {
                    if (_board.getButtonText(currentRow,currentCol) == "B")
                    {
                        button.BackgroundColor = Colors.Red;
                    }
                    else
                    {
                        button.BackgroundColor = Colors.White;
                    }
                }

                
            }
        }
    }



}