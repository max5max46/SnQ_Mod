using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class EnemyManager
    {
        private AttackMap attackMap;

        public EnemyManager(AttackMap attackMap)
        {
            this.attackMap = attackMap;
        }

        List<Enemy> enemies = new List<Enemy>();

        public void AddEnemy(EnemyTypeClass.EnemyType type, int x, int y, Render render, AttackMap attackMap, Map map)
        {
            enemies.Add(EnemyTypeClass.CreateEnemy(type, x, y, map, attackMap, render));
        }

        public void Update()
        {
            foreach (Enemy enemy in enemies)
                enemy.Update();
        }

        public void Draw()
        {
            foreach (Enemy enemy in enemies)
                enemy.Draw();
        }

        public void Bomb()
        {
            foreach (Enemy enemy in enemies)
                enemy.TakeDamage(Item.SMALL_BOMB_DAMAGE);
            attackMap.Flash();
        }
    }
}