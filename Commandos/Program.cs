using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("You must pass the API key as a command line argument");
                return;
            }
            string apiKey = args[0];
            Game game = new Game();
            game.Run();
        }
    }
}
