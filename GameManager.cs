using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class GameManager
    {
        static Map map = new Map();
        static Player player = new Player(5, 5, 10);
        static PlayerUI playerUI = new PlayerUI(player);
        static Render render = new Render(map, playerUI);
        static AttackMap attack = new AttackMap(map, render);

        // enemies
        static EnemyClass enemy1 = EnemyTypeClass.CreateEnemy(EnemyTypeClass.EnemyType.Enemy1, 10, 10);
        static EnemyClass enemy2 = EnemyTypeClass.CreateEnemy(EnemyTypeClass.EnemyType.Enemy2, 55, 20);

        public static ConsoleKey pressedKey;

        public static void StartGame()
        {
            Console.CursorVisible = false;

            player.GetMap(map);
            player.GetAttackMap(attack);

            enemy1.GetMap(map);
            enemy1.GetAttackMap(attack);
            enemy2.GetMap(map);
            enemy2.GetAttackMap(attack);

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
                if (player.GetDead())
                    break;

                playerUI.Draw(map);
                attack.Update();

                player.Update(render);
                enemy1.Update(render);
                enemy2.Update(render);
                player.CheckForDeath();

                map.Draw(render);
                player.Draw(render);
                enemy1.Draw(render);
                enemy2.Draw(render);
                attack.Draw();
                render.Draw();

                ClearInputBuffer();
                pressedKey = GetInput();

                playerUI.Draw(map);
            }
        }

        static void ClearInputBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        public static int[] GetPlayerPos()
        {
            return player.GetPos();
        }
    }
}