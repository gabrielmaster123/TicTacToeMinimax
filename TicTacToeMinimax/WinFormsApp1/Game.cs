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

            int countX = 0;
            int countO = 0;

            for (int i = 0; i < game.GetLength(0); i++)  // Iterate over rows
            {
                for (int j = 0; j < game.GetLength(1); j++)  // Iterate over columns
                {
                    if (game[i, j] == "X")
                    {
                        countX++;
                    }
                    else if (game[i, j] == "O")
                    {
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

    }

}
