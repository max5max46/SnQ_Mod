using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class GameManager
    {
        static Map map;
        static Render render;
        static AttackMap attack;
        static Player player;
        public static PlayerUI playerUI;
        public static EnemyManager enemyManager;
        public static ItemManager itemManager;

        public static ConsoleKey pressedKey;

        public static bool gameOver, gameWin;

        public static void InitializeObjects()
        {
            map = new Map();
            render = new Render(map);
            attack = new AttackMap(map, render);
            player = new Player(Global.START_X, Global.START_Y, map, attack, render);
            playerUI = new PlayerUI(player);
            itemManager = new ItemManager(render, attack, map, player);
            enemyManager = new EnemyManager(attack, player, render, map, itemManager);

            gameOver = false;
            gameWin = false;
        }
        
        public static void StartGame()
        {
            InitializeObjects();

            render.SetWindowSize(playerUI);
            Console.CursorVisible = false;

            player.GetEnemyManager(enemyManager);

            SpawnEnemies();
            SpawnItems();

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

                // break out to start a game over/win
                if (gameOver || gameWin) break;

                ClearInputBuffer();
                pressedKey = GetInput();
            }

            if (gameOver)
                GameOverSequence();
            if (gameWin)
                GameWinSequence();
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

        public static void GameOverSequence()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("GAME OVER");
            Console.WriteLine();
            Console.WriteLine("Press any key to start over");
            Console.ReadKey(true);
            StartGame();
        }
        public static void GameWinSequence()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("GAME WIN");
            Console.WriteLine();
            Console.WriteLine("Press any key to start over");
            Console.ReadKey(true);
            StartGame();
        }

        // SPAWNER METHODS

        public static void SpawnEnemies()
        {
            // roamers
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 13, 14);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 55, 17);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 55, 20);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 1, 37);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 75, 18);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 80, 16);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 75, 22);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 80, 23);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 70, 10);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 76, 12);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 80, 10);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 79, 5);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 75, 2);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 73, 6);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 20, 22);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 67, 15);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 66, 16);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 80, 30);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 68, 35);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 63, 31);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 52, 30);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Roamer, 13, 36);

            // chargers
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Charger, 1, 37);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Charger, 60, 10);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Charger, 79, 24);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Charger, 60, 16);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Charger, 71, 3);

            // swimmers
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Swimmer, 42, 20);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Swimmer, 42, 5);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Swimmer, 48, 40);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Swimmer, 22, 40);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Swimmer, 70, 40);

            // lava
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Lava, 37, 6);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Lava, 36, 8);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Lava, 58, 3);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Lava, 36, 39);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Lava, 66, 2);

            // elites
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Elite, 61, 6);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Elite, 67, 5);
            enemyManager.AddEnemy(EnemyTypeClass.EnemyType.Elite, 69, 4);
        }

        public static void SpawnItems()
        {
            // health pickups
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 1, 35);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 4, 37);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 4, 11);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 22, 9);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 35, 38);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 69, 1);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 69, 7);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 78, 17);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 69, 15);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 40, 30);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 42, 28);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 49, 2);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickup, 52, 1);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickupLarge, 56, 18);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickupLarge, 14, 20);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickupLarge, 60, 16);
            itemManager.AddItem(ItemTypeClass.ItemType.HealthPickupLarge, 36, 39);

            // weapons
            itemManager.AddItem(ItemTypeClass.ItemType.Spear, 59, 23);
            itemManager.AddItem(ItemTypeClass.ItemType.HulaHoop, 37, 40);

            // bombs
            itemManager.AddItem(ItemTypeClass.ItemType.Bomb, 33, 6);

            // key items
            itemManager.AddItem(ItemTypeClass.ItemType.Boat, 71, 3);
            itemManager.AddItem(ItemTypeClass.ItemType.Gem, 3, 3);
        }
    }
}