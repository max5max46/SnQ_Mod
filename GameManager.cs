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
        public static NPCManager npcManager;
        public static QuestManager questManager;
        public static Camera camera;

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
            npcManager = new NPCManager(attack, player, render, map, itemManager);
            enemyManager = new EnemyManager(attack, player, render, map, itemManager, npcManager);
            questManager = new QuestManager(render, attack, map, player);
            camera = new Camera(player, map);

            enemyManager.InitEnemies();
            itemManager.InitItems();
            npcManager.InitNPCs();
            questManager.InitQuests();
            gameOver = false;
            gameWin = false;
        }
        
        public static void StartGame()
        {
            InitializeObjects();

            Console.CursorVisible = false;

            player.GetEnemyManager(enemyManager);
            player.GetNPCManager(npcManager);
            render.GetCamera(camera);

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
                npcManager.Update();
                questManager.Update();
                camera.Update();

                playerUI.Draw(map);
                map.Draw(render);
                attack.Draw();
                enemyManager.Draw();
                itemManager.Draw();
                npcManager.Draw();
                questManager.Draw();
                player.Draw();
                render.Draw();

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
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
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
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            StartGame();
        }
    }
}