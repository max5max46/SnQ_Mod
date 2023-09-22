using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class RetiredSoldier : NPC
    {
        public RetiredSoldier(int x, int y, Map map, AttackMap attackMap, Render render, NPCTypeClass.NPCType type) : base(x, y, map, attackMap, render)
        {
            health = 1;
            maxHealth = 1;
            dialogueCycle = 0;
            character = Global.SOLDIER_CHAR;
            this.Type = type;
            name = "Retired Soldier";
        }
        public override void Interact()
        {
            switch (dialogueCycle)
            {
                case 0:
                    GameManager.playerUI.AddEvent("\"Huh, didn't expect anyone coming around here\" -" + name);
                    break;
                case 1:
                    GameManager.playerUI.AddEvent("\"I'll sell you my old weapons if you want, but don't expect me to help you fight\" -" + name);
                    break;
                case 2:
                    GameManager.playerUI.AddEvent("\"Be careful theres a cave north of here full of monsters\" -" + name); dialogueCycle = 0;
                    return;
            }
            dialogueCycle++;
        }
    }
}