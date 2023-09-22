using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class OldHermit : NPC
    {
        public OldHermit(int x, int y, Map map, AttackMap attackMap, Render render, NPCTypeClass.NPCType type) : base(x, y, map, attackMap, render)
        {
            health = 1;
            maxHealth = 1;
            dialogueCycle = 0;
            character = Global.HERMIT_CHAR;
            this.Type = type;
            name = "Old Hermit";
        }
        public override void Interact()
        {
            switch (dialogueCycle)
            {
                case 0:
                    GameManager.playerUI.AddEvent("\"Hehehehehe ooooo look at you hehehe\" -" + name);
                    break;
                case 1:
                    GameManager.playerUI.AddEvent("\"Need some fire power? hehe I've got just the thing hehe\" -" + name);
                    break;
                case 2:
                    GameManager.playerUI.AddEvent("\"If you buy it you'll never have to fight again hehe\" -" + name); dialogueCycle = 0;
                    return;
            }
            dialogueCycle++;
        }
    }
}