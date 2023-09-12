using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Enemy : GameCharacter
    {
        protected int moveCharge;
        protected int moveAt;
        protected EnemyTypeClass.EnemyType Type;

        public Enemy(int x, int y, Map map, AttackMap attackMap, Render render) : base(x, y, map, attackMap, render)
        {
            moveCharge = 0;
            color = ConsoleColor.Red;
            baseColor = color;
            attackColor = ConsoleColor.DarkBlue;
        }

        public override void Update()
        {
            base.Update();
            if (dead)
                return;
            moveCharge++;
            if (!MoveChargeCheck())
                return;
            MoveAI();
        }

        protected virtual void MoveAI()
        {
            return;
        }

        protected bool MoveChargeCheck()
        {
            if (moveCharge >= moveAt)
            {
                moveCharge = 0;
                return true;
            }
            return false;
        }

        protected override void Die()
        {
            base.Die();
        }

        public override void TakeDamage(int damageAmount, bool displayDamage = true)
        {
            if (attackMap.PlayerAttackCheck(x, y)) base.TakeDamage(damageAmount, displayDamage);
        }
        public void TakeDamageDirect(int damageAmount, bool displayDamage = true)
        {
            base.TakeDamage(damageAmount, displayDamage);
        }

        public EnemyTypeClass.EnemyType GetEnemyType()
        {
            return Type;
        }
    }
}