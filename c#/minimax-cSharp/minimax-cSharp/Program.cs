using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minimax_cSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager.SetBoard();
            minimax minimax = new minimax();

            Console.WriteLine("The best possible point is: "+ minimax.Minimax().point);

            //Console.WriteLine(" | X | O | X | \n | X | O | X | \n | X | O | X |");

            Console.ReadKey();
        }
    }
}
