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
        static AttackMap attack = new AttackMap(map);
        static Render render = new Render(map);
        static Player player = new Player(5, 5);

        // enemies
        static Enemy1 enemy1 = new Enemy1(7, 7);

        public static ConsoleKey pressedKey;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            player.GetMap(map);
            player.GetAttackMap(attack);

            enemy1.GetMap(map);
            enemy1.GetAttackMap(attack);

            GameLoop();
        }

        static public ConsoleKey GetInput()
        {
            return Console.ReadKey(true).Key;
        }

        static void GameLoop()
        {
            while (true)
            {
                attack.Update();

                player.Update();

                enemy1.Update();

                map.Draw(render);
                player.Draw(render);
                enemy1.Draw(render);
                render.Draw();

                ClearInputBuffer();
                pressedKey = GetInput();
            }
        }

        static void ClearInputBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}