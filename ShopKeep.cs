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
            health = 1;
            maxHealth = 1;
            dialogueCycle = 0;
            character = Global.SHOP_CHAR;
            this.Type = type;
            name = "Shop Keep";
        }
        public override void Interact()
        {
            switch (dialogueCycle)
            {
                case 0:
                    GameManager.playerUI.AddEvent("\"Hello! Welcome to my humble shop!\" -" + name);
                    break;
                case 1:
                    GameManager.playerUI.AddEvent("\"If you want to try your luck, talk to my friend the room over\" -" + name);
                    break;
                case 2:
                    GameManager.playerUI.AddEvent("\"Gem? no I don't have anything like that\" -" + name); dialogueCycle = 0;
                    return;
            }
            dialogueCycle++;
        }
    }
}