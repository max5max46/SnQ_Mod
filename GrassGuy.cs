using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class GrassGuy : NPC
    {
        public GrassGuy(int x, int y, Map map, AttackMap attackMap, Render render, NPCTypeClass.NPCType type) : base(x, y, map, attackMap, render)
        {
            health = 1;
            maxHealth = 1;
            dialogueCycle = 0;
            character = Global.GRASSGUY_CHAR;
            this.Type = type;
            name = "Grass Guy";
        }
        public override void Interact()
        {
            switch (dialogueCycle)
            {
                case 0:
                    GameManager.playerUI.AddEvent("\"Oh me? just enjoying this supreb grass!\" -" + name);
                    break;
                case 1:
                    GameManager.playerUI.AddEvent("\"Theres a fortress north of here, they say you need to sail up the river to get inside\" -" + name);
                    break;
                case 2:
                    GameManager.playerUI.AddEvent("\"Gem? oh, talk to the Mayor he can help\" -" + name); dialogueCycle = 0;
                    return;
            }
            dialogueCycle++;
        }
    }
}