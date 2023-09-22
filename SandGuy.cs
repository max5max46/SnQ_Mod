using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class SandGuy : NPC
    {
        public SandGuy(int x, int y, Map map, AttackMap attackMap, Render render, NPCTypeClass.NPCType type) : base(x, y, map, attackMap, render)
        {
            health = 1;
            maxHealth = 1;
            dialogueCycle = 0;
            character = Global.SANDGUY_CHAR;
            this.Type = type;
            name = "Sand Guy";
        }
        public override void Interact()
        {
            switch (dialogueCycle)
            {
                case 0:
                    GameManager.playerUI.AddEvent("\"Oh me? just enjoying this amazing sand!\" -" + name);
                    break;
                case 1:
                    GameManager.playerUI.AddEvent("\"If you head west along the cost you'll find a retired soldier, he's a pretty cool dude!\" -" + name);
                    break;
                case 2:
                    GameManager.playerUI.AddEvent("\"If you want to sign up to some quests before you go, just enter the building east of here!\" -" + name); dialogueCycle = 0;
                    return;
            }
            dialogueCycle++;
        }
    }
}