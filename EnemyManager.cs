using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace Text_Based_RPG
{
    internal class EnemyManager
    {
        private struct EnemyStats
        {
            public string name;
            public char characterOnEnemyMap;
            public char character;
            public int maxHealth;
            public int strength;
            public string attackShape;
            public bool kamikaze;
            public string moveType;
            public int moveAt;
        }

        private Render render;
        private Map map;
        private AttackMap attackMap;
        private Player player;
        private ItemManager itemManager;
        private NPCManager npcManager;

        private bool bossAlive;

        public EnemyManager(AttackMap attackMap, Player player, Render render, Map map, ItemManager itemManager, NPCManager npcManager)
        {
            this.attackMap = attackMap;
            this.player = player;
            this.render = render;
            this.map = map;
            this.itemManager = itemManager;
            this.npcManager = npcManager;
        }

        List<Enemy> enemies = new List<Enemy>();

        private void AddEnemy(int x, int y, EnemyStats enemyType)
        {
            enemies.Add(new Enemy(x, y, map, attackMap, render, enemyType.maxHealth, enemyType.moveAt, enemyType.character, enemyType.strength, enemyType.attackShape, enemyType.kamikaze, enemyType.moveType, enemyType.name));
            if (enemyType.name.Equals("elite", StringComparison.InvariantCultureIgnoreCase)) bossAlive = true;
        }

        public void Update()
        {
            bossAlive = false;

            foreach (Enemy enemy in enemies)
            {
                enemy.Update();
                if (enemy.GetEnemyName().Equals("elite", StringComparison.InvariantCultureIgnoreCase))
                    bossAlive = true;
            }

            if (attackMap.IsAttack(player.GetPos()[0], player.GetPos()[1]))
            {
                player.TakeDamage(attackMap.AttackStrength(player.GetPos()[0], player.GetPos()[1]));
            }

            if (!bossAlive)
                itemManager.ShowHidden();
        }

        public void Draw()
        {
            foreach (Enemy enemy in enemies)
                enemy.Draw();
        }

        public void Bomb()
        {
            foreach (Enemy enemy in enemies)
                enemy.TakeDamageDirect(Global.SMALL_BOMB_DAMAGE);
            attackMap.Flash();
        }

        public void DamageEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                if (attackMap.IsAttack(enemy.GetPos()[0], enemy.GetPos()[1]) && attackMap.PlayerAttackCheck(enemy.GetPos()[0], enemy.GetPos()[1]))
                {
                    enemy.TakeDamage(attackMap.AttackStrength(enemy.GetPos()[0], enemy.GetPos()[1]));
                }
            }
        }

        public void InitEnemies()
        {
            EnemyStats[] enemyTypes = InitEnemyTypes();
            string[] mapString = File.ReadAllLines("Enemies.txt");
            char[,] enemyMap = new char[mapString.GetLength(0), mapString[0].Length];

            for (int i = 0; i < mapString.GetLength(0); i++)
                for (int j = 0; j < mapString[0].Length; j++)
                    enemyMap[i, j] = mapString[i][j];
            
            for (int i = 0; i < enemyMap.GetLength(0); i++)
                for (int j = 0; j < enemyMap.GetLength(1); j++)
                    foreach (EnemyStats enemyType in enemyTypes)
                        if (enemyMap[i,j] == enemyType.characterOnEnemyMap)
                            AddEnemy(j, i, enemyType);
        }

        private EnemyStats[] InitEnemyTypes()
        {
            string txtEnemies;
            string[] txtEnemyTypes;
            string[] txtEnemyStats;
            EnemyStats[] enemyTypes;
            int enemyTypesIndex = 0;

            txtEnemies = File.ReadAllText("EnemyTypes.txt");
            txtEnemyTypes = txtEnemies.Split('{');
            enemyTypes = new EnemyStats[txtEnemyTypes.GetLength(0) - 1];

            foreach (string txtEnemyType in txtEnemyTypes)
            {
                if (txtEnemyType.Contains('}'))
                {
                    txtEnemyStats = txtEnemyType.Split('[');
                    foreach (string txtEnemyStat in txtEnemyStats)
                    {
                        if (txtEnemyType.Contains(']'))
                        {
                            switch (txtEnemyStat.ToLower())
                            {
                                case string s when s.Contains("name"):
                                    if (txtEnemyStat.IndexOf('(') != -1 && txtEnemyStat.IndexOf(')') != -1)
                                        enemyTypes[enemyTypesIndex].name = txtEnemyStat.Substring(txtEnemyStat.IndexOf('(') + 1, txtEnemyStat.IndexOf(')') - (txtEnemyStat.IndexOf('(') + 1));
                                    break;

                                case string s when s.Contains("symbol used in enemy map"):
                                    if (txtEnemyStat.IndexOf('(') != -1 && txtEnemyStat.IndexOf(')') != -1)
                                        enemyTypes[enemyTypesIndex].characterOnEnemyMap = txtEnemyStat.Substring(txtEnemyStat.IndexOf('(') + 1, txtEnemyStat.IndexOf(')') - (txtEnemyStat.IndexOf('(') + 1))[0];
                                    break;

                                case string s when s.Contains("symbol used in gameplay"):
                                    if (txtEnemyStat.IndexOf('(') != -1 && txtEnemyStat.IndexOf(')') != -1)
                                        enemyTypes[enemyTypesIndex].character = txtEnemyStat.Substring(txtEnemyStat.IndexOf('(') + 1, txtEnemyStat.IndexOf(')') - (txtEnemyStat.IndexOf('(') + 1))[0];
                                    break;

                                case string s when s.Contains("health"):
                                    if (txtEnemyStat.IndexOf('(') != -1 && txtEnemyStat.IndexOf(')') != -1)
                                        enemyTypes[enemyTypesIndex].maxHealth = Int32.Parse(txtEnemyStat.Substring(txtEnemyStat.IndexOf('(') + 1, txtEnemyStat.IndexOf(')') - (txtEnemyStat.IndexOf('(') + 1)));
                                    break;

                                case string s when s.Contains("strength"):
                                    if (txtEnemyStat.IndexOf('(') != -1 && txtEnemyStat.IndexOf(')') != -1)
                                        enemyTypes[enemyTypesIndex].strength = Int32.Parse(txtEnemyStat.Substring(txtEnemyStat.IndexOf('(') + 1, txtEnemyStat.IndexOf(')') - (txtEnemyStat.IndexOf('(') + 1)));
                                    break;

                                case string s when s.Contains("attack shape"):
                                    if (txtEnemyStat.IndexOf('(') != -1 && txtEnemyStat.IndexOf(')') != -1)
                                        enemyTypes[enemyTypesIndex].attackShape = txtEnemyStat.Substring(txtEnemyStat.IndexOf('(') + 1, txtEnemyStat.IndexOf(')') - (txtEnemyStat.IndexOf('(') + 1));
                                    break;

                                case string s when s.Contains("will kamikaze"):
                                    if (txtEnemyStat.IndexOf('(') != -1 && txtEnemyStat.IndexOf(')') != -1)
                                        enemyTypes[enemyTypesIndex].kamikaze = bool.Parse(txtEnemyStat.Substring(txtEnemyStat.IndexOf('(') + 1, txtEnemyStat.IndexOf(')') - (txtEnemyStat.IndexOf('(') + 1)));
                                    break;

                                case string s when s.Contains("movement type"):
                                    if (txtEnemyStat.IndexOf('(') != -1 && txtEnemyStat.IndexOf(')') != -1)
                                        enemyTypes[enemyTypesIndex].moveType = txtEnemyStat.Substring(txtEnemyStat.IndexOf('(') + 1, txtEnemyStat.IndexOf(')') - (txtEnemyStat.IndexOf('(') + 1));
                                    break;

                                case string s when s.Contains("movement cooldown"):
                                    if (txtEnemyStat.IndexOf('(') != -1 && txtEnemyStat.IndexOf(')') != -1)
                                        enemyTypes[enemyTypesIndex].moveAt = Int32.Parse(txtEnemyStat.Substring(txtEnemyStat.IndexOf('(') + 1, txtEnemyStat.IndexOf(')') - (txtEnemyStat.IndexOf('(') + 1)));
                                    break;
                            }
                        }
                    }
                    enemyTypesIndex++;
                }
            }

            return enemyTypes;
        }
    }
}