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
        private Player player;

        public EnemyManager(AttackMap attackMap, Player player)
        {
            this.attackMap = attackMap;
            this.player = player;
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

            if (attackMap.IsAttack(player.GetPos()[0], player.GetPos()[1]))
            {
                player.TakeDamage(attackMap.AttackStrength(player.GetPos()[0], player.GetPos()[1]));
            }
        }

        public void Draw()
        {
            foreach (Enemy enemy in enemies)
                enemy.Draw();
        }

        public void Bomb()
        {
            foreach (Enemy enemy in enemies)
                enemy.TakeDamage(Global.SMALL_BOMB_DAMAGE);
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
    }
}