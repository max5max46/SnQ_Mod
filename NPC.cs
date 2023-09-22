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
        protected int dialogueCycle;

        public NPC(int x, int y, Map map, AttackMap attackMap, Render render) : base(x, y, map, attackMap, render)
        {
            moveCharge = 0;
            color = ConsoleColor.Green;
            baseColor = color;
        }

        public override void Update()
        {
            base.Update();
        }
        public NPCTypeClass.NPCType GetNPCType()
        {
            return Type;
        }

        public virtual void Interact()
        {

        }

        protected override void Die()
        {
        }

        public override void TakeDamage(int damageAmount, bool displayDamage = true)
        {
        }

    }
}