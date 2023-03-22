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
        static Player player = new Player(3, 3, map, attack, render);
        public static PlayerUI playerUI = new PlayerUI(player);
        public static EnemyManager enemyManager = new EnemyManager(attack, player);
        public static ItemManager itemManager = new ItemManager();

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
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 4, 11, render, attack, map, player);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 22, 9, render, attack, map, player);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 35, 38, render, attack, map, player);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 69, 1, render, attack, map, player);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 69, 7, render, attack, map, player);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 56, 18, render, attack, map, player);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickupLarge, 14, 20, render, attack, map, player);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickupLarge, 60, 16, render, attack, map, player);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickupLarge, 36, 39, render, attack, map, player);

            // weapons
            itemManager.AddItem(ItemTypeClass.ItemType.Spear, 59, 23, render, attack, map, player);
            itemManager.AddItem(ItemTypeClass.ItemType.HulaHoop, 37, 40, render, attack, map, player);

            // bombs
            itemManager.AddItem(ItemTypeClass.ItemType.Bomb, 33, 6, render, attack, map, player);

            // key items
            itemManager.AddItem(ItemTypeClass.ItemType.Boat, 71, 3, render, attack, map, player);


            // INIT enemies

            // roamers
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 13, 14, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 55, 17, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 55, 20, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 1, 37, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 75, 18, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 80, 16, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 75, 22, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 80, 23, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 70, 10, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 76, 12, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 80, 10, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 79, 5, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 75, 2, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 73, 6, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 20, 22, render, attack, map);

            // chargers
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Charger, 1, 37, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Charger, 60, 10, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Charger, 79, 24, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Charger, 60, 16, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Charger, 71, 3, render, attack, map);

            // swimmers
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Swimmer, 42, 20, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Swimmer, 42, 5, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Swimmer, 48, 40, render, attack, map);

            // lava
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Lava, 37, 6, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Lava, 36, 8, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Lava, 58, 3, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Lava, 36, 39, render, attack, map);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Lava, 66, 2, render, attack, map);


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