using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class DockGuy : NPC
    {
        public DockGuy(int x, int y, Map map, AttackMap attackMap, Render render, NPCTypeClass.NPCType type) : base(x, y, map, attackMap, render)
        {
            health = 1;
            maxHealth = 1;
            dialogueCycle = 0;
            character = Global.DOCKGUY_CHAR;
            this.Type = type;
            name = "Dock Guy";
        }
        public override void Interact()
        {
            switch (dialogueCycle)
            {
                case 0:
                    GameManager.playerUI.AddEvent("\"Oh me? I'm just enjoying this wonderful dock\" -" + name);
                    break;
                case 1:
                    GameManager.playerUI.AddEvent("\"Some people say if you follow the old dock heading west, theres a fortress at the end!\" -" + name);
                    break;
                case 2:
                    GameManager.playerUI.AddEvent("\"If you need a way to cross water, go to the fisherman's shack on the water\" -" + name); dialogueCycle = 0;
                    return;
            }
            dialogueCycle++;
        }
    }
}