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
        static Player player = new Player(3, 3, 10, map, attack, render);
        public static PlayerUI playerUI = new PlayerUI(player);
        public static EnemyManager enemyManager = new EnemyManager(attack, player);
        public static ItemManager itemManager = new ItemManager();
        public static Random random = new Random();

        public static ConsoleKey pressedKey;

        public static void StartGame()
        {
            render.SetWindowSize(playerUI);
            Console.CursorVisible = false;

            player.GetEnemyManager(enemyManager);

            // INIT items

            // health pickups
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 1, 35, render, attack, map, player);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 4, 37, render, attack, map, player);
            // weapons
            itemManager.AddItem(ItemTypeClass.ItemType.Spear, 59, 23, render, attack, map, player);

            // key items
            itemManager.AddItem(ItemTypeClass.ItemType.Boat, 71, 3, render, attack, map, player);


            // INIT enemies


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

                map.Draw(render);
                attack.Draw();
                enemyManager.Draw();
                itemManager.Draw();
                player.Draw();
                render.Draw();
                playerUI.Draw(map);

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

        public static int[] GetPlayerPos()
        {
            return player.GetPos();
        }
    }
}