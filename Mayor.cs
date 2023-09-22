using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Mayor : NPC
    {
        public Mayor(int x, int y, Map map, AttackMap attackMap, Render render, NPCTypeClass.NPCType type) : base(x, y, map, attackMap, render)
        {
            health = 1;
            maxHealth = 1;
            dialogueCycle = 0;
            character = Global.MAYOR_CHAR;
            this.Type = type;
            name = "Mayor";
        }
        public override void Interact()
        {
            switch (dialogueCycle)
            {
                case 0:
                    GameManager.playerUI.AddEvent("\"A gem you say? yes I have it but I need a favor\" -" + name);
                    break;
                case 1:
                    GameManager.playerUI.AddEvent("\"Kill all the elites in the area and I'll sell you one\" -" + name);
                    break;
                case 2:
                    GameManager.playerUI.AddEvent("\"Need help? talk to the Guys, they'll point you in the right direction\" -" + name);
                    break;
                case 3:
                    GameManager.playerUI.AddEvent("\"Come back when your done, I'll have the gem ready\" -" + name); dialogueCycle = 3;
                    return;
            }
            dialogueCycle++;
        }
    }
}