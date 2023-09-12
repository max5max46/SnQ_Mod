using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class NPC : GameCharacter
    {
        protected int moveCharge;
        protected int moveAt;
        protected NPCTypeClass.NPCType Type;

        public NPC(int x, int y, Map map, AttackMap attackMap, Render render) : base(x, y, map, attackMap, render)
        {
            moveCharge = 0;
            color = ConsoleColor.Green;
            baseColor = color;
        }

        public override void Update()
        {
            base.Update();
            if (dead)
                return;
        }

        protected override void Die()
        {
            base.Die();
        }

        public override void TakeDamage(int damageAmount)
        {
            if (attackMap.PlayerAttackCheck(x, y)) base.TakeDamage(damageAmount);
        }
        public void TakeDamageDirect(int damageAmount)
        {
            base.TakeDamage(damageAmount);
        }

        public NPCTypeClass.NPCType GetNPCType()
        {
            return Type;
        }
    }
}