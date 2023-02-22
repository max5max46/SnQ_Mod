using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class EnemyManager
    {
        List<EnemyClass> enemies = new List<EnemyClass>();

        public void AddEnemy(EnemyTypeClass.EnemyType type, int x, int y, Render render, AttackMap attackMap, Map map)
        {
            enemies.Add(EnemyTypeClass.CreateEnemy(type, x, y, map, attackMap, render));
        }

        public void Update()
        {
            foreach (EnemyClass enemy in enemies)
                enemy.Update();
        }

        public void Draw()
        {
            foreach (EnemyClass enemy in enemies)
                enemy.Draw();
        }

        public void Bomb()
        {
            foreach (EnemyClass enemy in enemies)
                enemy.TakeDamage(5);
        }
    }
}