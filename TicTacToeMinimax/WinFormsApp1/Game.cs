using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Game
    {
        private String[,] gameArr = new String[3, 3];
        public Game()
        {
            
        }

        public String[,] GameArr { get => gameArr; set => gameArr = value; }

        public void PrintGame(Label label)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < gameArr.GetLength(0); i++)
            {
                for (int j = 0; j < gameArr.GetLength(1); j++)
                {
                    output.Append(gameArr[i, j]);
                }
                output.AppendLine();
            }

            label.Text = output.ToString();
        }

        public String Turn(String[,] game)
        {
            int count = 0;
            int countX = 0;
            int countO = 0;

            for (int i = 0; i < game.GetLength(0); i++)  // Iterate over rows
            {
                for (int j = 0; j < game.GetLength(1); j++)  // Iterate over columns
                {
                    if (game[i, j] == "X")
                    {
                        count++;
                        countX++;
                    }
                    else if (game[i, j] == "O")
                    {
                        count++;
                        countO++;
                    }
                }
            }
            if (countX == countO)
            {
                return "X";
            }
            else
            {
                return "O";
            }
        }

        public string CheckWinner()
        {
            // Check rows
            for (int i = 0; i < gameArr.GetLength(0); i++)
            {
                if (gameArr[i, 0] != null && gameArr[i, 0] == gameArr[i, 1] && gameArr[i, 1] == gameArr[i, 2])
                {
                    return gameArr[i, 0];  // Return "X" or "O" if a winner is found
                }
            }

            // Check columns
            for (int j = 0; j < gameArr.GetLength(1); j++)
            {
                if (gameArr[0, j] != null && gameArr[0, j] == gameArr[1, j] && gameArr[1, j] == gameArr[2, j])
                {
                    return gameArr[0, j];  // Return "X" or "O" if a winner is found
                }
            }

            // Check diagonals
            if (gameArr[0, 0] != null && gameArr[0, 0] == gameArr[1, 1] && gameArr[1, 1] == gameArr[2, 2])
            {
                return gameArr[0, 0];  // Return "X" or "O" if a winner is found
            }

            if (gameArr[0, 2] != null && gameArr[0, 2] == gameArr[1, 1] && gameArr[1, 1] == gameArr[2, 0])
            {
                return gameArr[0, 2];  // Return "X" or "O" if a winner is found
            }

            return null;  // No winner
        }


    }

}
