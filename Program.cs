using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Program
    {
        static Map map = new Map();
        static Player player = new Player(5, 5);
        public static ConsoleKey pressedKey;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            map.Draw();
            player.Draw();

            Console.ReadKey(true);
        }

        static public ConsoleKey GetInput()
        {
            return Console.ReadKey(true).Key;
        }

        static void GameLoop()
        {
            while (true)
            {
                player.Update();
                map.Draw();
                player.Draw();
                pressedKey = GetInput();
            }
        }
    }
}