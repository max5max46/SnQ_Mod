using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Text_Based_RPG
{
    internal class EnemyManager
    {
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

        public void AddEnemy(EnemyTypeClass.EnemyType Type, int x, int y)
        {
            enemies.Add(EnemyTypeClass.CreateEnemy(Type, x, y, map, attackMap, render));
            if (Type == EnemyTypeClass.EnemyType.Elite) bossAlive = true;
        }

        public void Update()
        {
            bossAlive = false;

            foreach (Enemy enemy in enemies)
            {
                enemy.Update();
                if (enemy.GetEnemyType() == EnemyTypeClass.EnemyType.Elite && !enemy.GetDead())
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
            string[] mapString = File.ReadAllLines("Enemies.txt");
            char[,] enemyMap = new char[mapString.GetLength(0), mapString[0].Length];

            for (int i = 0; i < mapString.GetLength(0); i++)
                for (int j = 0; j < mapString[0].Length; j++)
                    enemyMap[i, j] = mapString[i][j];
            
            for (int i = 0; i < enemyMap.GetLength(0); i++)
                for (int j = 0; j < enemyMap.GetLength(1); j++)
                {
                    switch (enemyMap[i, j])
                    {
                        case Global.CHARGER_CHAR:
                            AddEnemy(EnemyTypeClass.EnemyType.Charger, j, i);
                            break;
                        case Global.ELITE_CHAR:
                            AddEnemy(EnemyTypeClass.EnemyType.Elite, j, i);
                            break;
                        case Global.SWIMMER_CHAR:
                            AddEnemy(EnemyTypeClass.EnemyType.Swimmer, j, i);
                            break;
                        case Global.ROAMER_CHAR:
                            AddEnemy(EnemyTypeClass.EnemyType.Roamer, j, i);
                            break;
                        case Global.LAVA_CHAR:
                            AddEnemy(EnemyTypeClass.EnemyType.Lava, j, i);
                            break;
                    }
                }
        }
    }
}