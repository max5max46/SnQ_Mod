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
        static Render render = new Render(map);
        static AttackMap attack = new AttackMap(map, render);
        static Player player = new Player(5, 5, 10, map, attack, render);
        public static PlayerUI playerUI = new PlayerUI(player);
        public static EnemyManager enemyManager = new EnemyManager(attack);
        public static ItemManager itemManager = new ItemManager();
        public static Random random = new Random();

        public static ConsoleKey pressedKey;

        public static void StartGame()
        {
            render.SetWindowSize(playerUI);
            Console.CursorVisible = false;

            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 10, 7, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Charger, 40, 10, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Lava, 33, 17, render, attack, map);
            itemManager.AddItem(ItemTypeClass.ItemType.Bomb, 57, 18, render, attack, map, player);
            itemManager.AddItem(ItemTypeClass.ItemType.Spear, 51, 10, render, attack, map, player);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 15, 22, render, attack, map, player);

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

                attack.Update();
                player.Update();
                enemyManager.Update();
                itemManager.Update();

                player.CheckForDeath();

                map.Draw(render);
                attack.Draw();
                player.Draw();
                enemyManager.Draw();
                itemManager.Draw();
                render.Draw();
                playerUI.Draw(map);

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

        public static void SetLastEnemy(string name)
        {
            playerUI.lastEnemy = name;
        }
    }
}