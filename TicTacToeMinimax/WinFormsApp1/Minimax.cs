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
            int value = 0;
            Point bestMove = new Point(-1,-1);

            int bestValue = game.Turn() == "X" ? int.MaxValue : int.MinValue;

            foreach (Point move  in AllPossibleMoves(game))
            {
                Game tempGame = new Game();
                Array.Copy(game.GameArr, tempGame.GameArr, game.GameArr.Length);

                tempGame.GameArr[move.X, move.Y] = tempGame.Turn();

                if (game.Turn() == "X") {
                    value = Alg(tempGame, false); 
                } else 
                { 
                    value = Alg(tempGame, true); 
                }


                if (game.Turn() == "X" && 
                    value <= bestValue)
                {

                    bestMove = move;
                    bestValue = value; // Update the best value for minimizer
                }
                else if (game.Turn() == "O" && 
                     value >= bestValue)
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

        public int getValue(Game game)
        {
            return Alg(game, game.Turn()=="O");
        }

        private int Alg(Game game, bool isMax)
        {

            int alpha = int.MinValue;
            int beta = int.MaxValue;
            int value = 0;//if something goes wrong its probably gonna be this ngl
            
            String winner = game.CheckWinner();
            if (winner == "X") return int.MinValue;//minimise
            if (winner == "O") return int.MaxValue;//maximise

            if (AllPossibleMoves(game).Count == 0) return 0;//tie
            
            
            if(game.Turn() == "X")
            {
                value = int.MaxValue;
                foreach (Point move in AllPossibleMoves(game))
                {
                    Game tempGame = new Game();
                    Array.Copy(game.GameArr, tempGame.GameArr, game.GameArr.Length);
                    tempGame.GameArr[move.X, move.Y] = tempGame.Turn();
                    value = Math.Min(value, Alg(tempGame, false));
                    if (value <= alpha)
                    {
                        break;
                    }
                }
            }
            else
            {
                value = int.MinValue;
                foreach (Point move in AllPossibleMoves(game))
                {
                    Game tempGame = new Game();
                    Array.Copy(game.GameArr, tempGame.GameArr, game.GameArr.Length);
                    tempGame.GameArr[move.X, move.Y] = tempGame.Turn();
                    value = Math.Max(value, Alg(tempGame, true));
                    if (beta <= value)
                    {
                        break;
                    }
                }
            }
            
            return value;
        }
    }
}
