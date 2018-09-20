using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minimax_cSharp
{
    static class GameManager
    {
        public static char Player1Piece = 'X';
        public static char Player2Piece = 'O';

        public static char[] gameboard = new char[9];
        public static List<int> EmptyBoardPoints = new List<int>();

        public static int[,] winCombos = new int[8, 3] {
        { 0, 1, 2 }, // winCombos[0,0] , [0,1], [0,2]
        { 3, 4, 5 },
        { 6, 7, 8 },
        { 0, 3, 6 },
        { 1, 4, 7 },
        { 2, 5, 8 },
        { 0, 4, 8 },
        { 6, 4, 2 } };   // [7,0] , [7,1] , [7,2]

        //Initialize board space

        public static void InitBoard()
        {
            gameboard[0] = 'Z';
            gameboard[1] = 'Z';
            gameboard[2] = 'Z';
            gameboard[3] = 'Z';
            gameboard[4] = 'Z';
            gameboard[5] = 'Z';
            gameboard[6] = 'Z';
            gameboard[7] = 'Z';
            gameboard[8] = 'Z';
        }

        public static void SetBoard()
        {
            gameboard[0] = 'O';
            gameboard[1] = 'Z';
            gameboard[2] = 'Z';
            gameboard[3] = 'O';
            gameboard[4] = 'X';
            gameboard[5] = 'Z';
            gameboard[6] = 'Z';
            gameboard[7] = 'X';
            gameboard[8] = 'Z';

            //add empty points
            EmptyBoardPoints.Add(1);
            EmptyBoardPoints.Add(2);
            EmptyBoardPoints.Add(5);
            EmptyBoardPoints.Add(6);
            EmptyBoardPoints.Add(8);

        }

    }
}
