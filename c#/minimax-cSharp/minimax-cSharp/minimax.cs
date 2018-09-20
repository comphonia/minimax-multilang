using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minimax_cSharp
{
    public struct AIMove
    {
        public int score;
        public int point;
        public AIMove(int _score, int _point)
        {
            score = _score;
            point = _point;
        }
    }
    class minimax
    {
        private int[,] winCombos;
        private List<AIMove> aiMoves = new List<AIMove>();
        private List<int> emptyPoints;
 
        private int count;

        /// <summary>
        /// Calls the minimax function
        /// </summary>
        /// <returns></returns>
        public AIMove Minimax()
        {
            winCombos = GameManager.winCombos;
            emptyPoints = new List<int>(GameManager.EmptyBoardPoints);
            char[] board = new char[9]; System.Array.Copy(GameManager.gameboard, board, 9);
            aiMoves = new List<AIMove>();
            return GetBestMove(board, GameManager.Player2Piece, 0);
        }

        private AIMove GetBestMove(char[] board, char player, int index)
        {            
               //Terminal States
                AIMove terminalMove = new AIMove();
                if (CheckVictorySim(board, GameManager.Player1Piece) == true) // Human Player wins
                {
                    terminalMove.score = -10;
                    terminalMove.point = index;
                    return terminalMove;
                }
                else if (CheckVictorySim(board, GameManager.Player2Piece) == true) // else if return victory for AI Player
                {
                    terminalMove.score = 10;
                    terminalMove.point = index;
                    return terminalMove;
                }
                else if (emptyPoints.Count <= 0) // draw
                {
                    terminalMove.score = 0;
                    terminalMove.point = index;
                    return terminalMove;
                }
                else // NO WLD
                {
                    if (count >= 1)
                    {
                        count++;
                        terminalMove.score = -50;
                        terminalMove.point = index;
                        return terminalMove;

                    }
                    else
                    {
                        count++;
                    }


                }

                //Recursive function is called at each iteration
                for (int i = 0; i < emptyPoints.Count; i++)
                {
                    AIMove move = new AIMove();

                    if (player == GameManager.Player2Piece)
                    {
                        board[System.Convert.ToInt32(emptyPoints[i])] = player; // AI - adds a simulated piece on the test board to check for a Win Loss or Draw
                        player = GameManager.Player1Piece;
                        index = System.Convert.ToInt32(emptyPoints[i]);
                        var result = GetBestMove(board, GameManager.Player2Piece, index);
                        move.score = result.score;
                        move.point = result.point;
                        this.aiMoves.Add(move);
                    }
                    if (player == GameManager.Player1Piece)
                    {
                        board[System.Convert.ToInt32(emptyPoints[i])] = player; // Human - adds a simulated piece on the test board to check for a Win Loss or Draw
                        player = GameManager.Player2Piece;
                        index = System.Convert.ToInt32(emptyPoints[i]);
                        var result = GetBestMove(board, GameManager.Player1Piece, index);
                        move.score = result.score;
                        move.point = result.point;
                        this.aiMoves.Add(move);
                    }
                    board[System.Convert.ToInt32(emptyPoints[i])] = 'Z';
                }


                //Logic for picking the best move for current player

                var bestMove = 0;

                if (player == GameManager.Player2Piece) // AI player
                {
                    int bestScore = -10000;
                    for (int i = 0; i < aiMoves.Count; i++)
                    {
                        if (aiMoves[i].score > bestScore)
                        {
                            bestMove = i;
                            bestScore = aiMoves[i].score;

                        }
                    }
                }
                else if (player == GameManager.Player1Piece) // Human Player
                {
                    int bestScore = 10000;
                    for (int i = 0; i < aiMoves.Count; i++)
                    {
                        if (aiMoves[i].score < bestScore)
                        {
                            bestMove = i;
                            bestScore = aiMoves[i].score;
                        }
                    }
                }

                // Zero the count value
                count = 0;
                //return the best move
                return aiMoves[bestMove];
            

        }

        private bool CheckVictorySim(char[] board, char playerPiece)
        {
            char piece = playerPiece;
            for (int i = 0; i < 8; i++)
            {
                if (board[winCombos[i, 0]] == piece && board[winCombos[i, 1]] == piece && board[winCombos[i, 2]] == piece)
                {
                    Console.WriteLine("Player "+ piece + " wins at point " + emptyPoints[i]);
                    return true;
                }

            }

            return false;

        }


    }

}
