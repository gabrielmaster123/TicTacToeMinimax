using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Minimax//X is Mini O is Max
    {
        //Diese Klasse ohne Hilfe von chatgpt erstellt ganz krass

        public Point BestMove(Game game)
        {
            Point bestMove = new Point(-1,-1);

            int bestValue = game.Turn() == "X" ? int.MaxValue : int.MinValue;

            foreach (Point move  in AllPossibleMoves(game))
            {
                Game tempGame = new Game();
                Array.Copy(game.GameArr, tempGame.GameArr, game.GameArr.Length);

                tempGame.GameArr[move.X, move.Y] = tempGame.Turn();

                int value = Alg(tempGame);

                if (game.Turn() == "X" && 
                    value < bestValue)
                {
                    bestMove = move;
                    bestValue = value; // Update the best value for minimizer
                }
                else if (game.Turn() == "O" && 
                    value > bestValue)
                {
                    bestMove = move;
                    bestValue = value; // Update the best value for maximizer
                }
            }
            
            
            return bestMove;
        }

        private List<Point> AllPossibleMoves(Game game)
        {
            List<Point> moves = new List<Point>(); ;
            for (int i = 0; i < game.GameArr.GetLength(0); i++)
            {
                for (int j = 0; j < game.GameArr.GetLength(1); j++)
                {
                    if (game.GameArr[i, j] == null)
                    {
                        moves.Add(new Point(i,j));
                    }
                }
            }

            return moves;
        }

        private int Alg(Game game)
        {
            int value = 0;
            if(game.CheckWinner() == "X")
            {
                return -1;//minimise
            }
            
            if(game.CheckWinner() == "O")
            {
                return +1;//maximise
            }

            if(AllPossibleMoves(game).Count == 0)
            {
                return 0;//tie
            }
            
            if(game.Turn() == "X")
            {
                value = int.MaxValue;

            }else if(game.Turn() == "O")
            {
                value = int.MinValue;
            }

            foreach(Point move in AllPossibleMoves(game))
            {

                Game tempGame = new Game();
                Array.Copy(game.GameArr, tempGame.GameArr, game.GameArr.Length);

                tempGame.GameArr[move.X, move.Y] = tempGame.Turn();

                int tempValue = Alg(tempGame);
                if (game.Turn() == "X")
                {
                    value = Math.Min(value, tempValue);
                }
                else
                {
                    value = Math.Max(value, tempValue);
                }
            }
            
            return value;
        }
    }
}
