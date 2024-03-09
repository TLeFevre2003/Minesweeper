using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1;

class Board
{
    private int _rows;
    private int _columns;
    private int _bombCount;
    private bool _clicked = false;

    private int[,,] gameBoard = new int[0, 0, 0];
    public Board(int row, int column, int bombs)
    {
        this._rows = row;
        this._columns = column;
        this._bombCount = bombs;

        gameBoard = new int[row, column,2];
    }

    private void initializeBoard()
    {

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                gameBoard[i, j, 1] = 0;
                gameBoard[i, j,0] = 0;
            }
        }


    }
    private void setBombs(int startx, int starty)
    {

        int placedBombs = 0;
        Random randomGenerator = new Random();


        while (placedBombs < _bombCount)
        {
            int x = randomGenerator.Next(0,_rows);
            int y = randomGenerator.Next(0, _columns);

            if (gameBoard[x,y,0] == 0 && x!= startx && y!=starty)
            {
                gameBoard[x, y,0] = 9;
                placedBombs++;
            }



        }


    }
    private void initializeTileValues()
    {

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                if (gameBoard[i, j, 0] != 9)
                {
                    int count = 0;
                    for (int x = Math.Max(i - 1, 0); x <= Math.Min(i + 1, _rows - 1); x++)
                    {
                        for (int y = Math.Max(j - 1, 0); y <= Math.Min(j + 1, _columns - 1); y++)
                        {
                            if (gameBoard[x,y,0] == 9)
                            {
                                count++;
                            }
                        }
                    }
                    gameBoard[i, j, 0] = count;
                }
            }
        }
        
    }
    private void revealTiles()
    {
        bool done = false;
        while (!done)
        {
            done = true;
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    if (gameBoard[i, j, 1] == 1 && gameBoard[i, j, 0] == 0)
                    {
                        for (int x = Math.Max(i - 1, 0); x <= Math.Min(i + 1, _rows - 1); x++)
                        {
                            for (int y = Math.Max(j - 1, 0); y <= Math.Min(j + 1, _columns - 1); y++)
                            {
                                if (gameBoard[x, y, 1] == 0)
                                {
                                    Console.WriteLine("x y " + x + " " + y);
                                    gameBoard[x, y, 1] = 1;
                                    done = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }


    public string getButtonText(int x, int y)
    {
        if (gameBoard[x, y, 1] ==  0)
        {
            return " ";
        }
        if (gameBoard[x,y,0] == 0)
        {
            return " ";
        }
        if ((gameBoard[x,y,0] == 9))
        {
            return "B";
        }
        return gameBoard[x, y,0].ToString();
    }
    public void incrementButton(int x, int y)
    {
        gameBoard[x, y,0]++;
    }
    public void clicked(int x, int y)
    {
        if (_clicked == false)
        {
            setBombs(x,y);
            initializeTileValues();
            _clicked = true;
        }

        gameBoard[x, y, 1] = 1;
        revealTiles();
    }
    public bool isShowing(int x, int y)
    {
        return gameBoard[x,y,1] == 1;
    }
}