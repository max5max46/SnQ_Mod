using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class ShopKeep : NPC
    {
        public ShopKeep(int x, int y, Map map, AttackMap attackMap, Render render, NPCTypeClass.NPCType type) : base(x, y, map, attackMap, render)
        {
            health = Global.SHOP_HP;
            maxHealth = Global.SHOP_HP;
            character = Global.SHOP_CHAR;
            this.Type = type;
            name = type.ToString();
        }
    }
}