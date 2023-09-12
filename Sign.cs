using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Sign : NPC
    {
        public Sign(int x, int y, Map map, AttackMap attackMap, Render render, NPCTypeClass.NPCType type) : base(x, y, map, attackMap, render)
        {
            health = Global.SIGN_HP;
            maxHealth = Global.SIGN_HP;
            character = Global.SIGN_CHAR;
            this.Type = type;
            name = type.ToString();
        }

        public override void TakeDamage(int damageAmount, bool displayDamage = true)
        {
            GameManager.playerUI.AddEvent("\"The Totally Legit Shop!!!\" -" + name);

            base.TakeDamage(damageAmount, false);
        }
    }
}