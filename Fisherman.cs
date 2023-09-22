using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Fisherman : NPC
    {
        public Fisherman(int x, int y, Map map, AttackMap attackMap, Render render, NPCTypeClass.NPCType type) : base(x, y, map, attackMap, render)
        {
            health = 1;
            maxHealth = 1;
            dialogueCycle = 0;
            character = Global.FISHERMAN_CHAR;
            this.Type = type;
            name = "Fisherman";
        }
        public override void Interact()
        {
            switch (dialogueCycle)
            {
                case 0:
                    GameManager.playerUI.AddEvent("\"Aye lad, what can i do for thee?\" -" + name);
                    break;
                case 1:
                    GameManager.playerUI.AddEvent("\"If ye need a boat, you can buy me old one sitting over there\" -" + name);
                    break;
                case 2:
                    GameManager.playerUI.AddEvent("\"Ye know, there used to be a old man 'round here, sailed off one day and I aven't seen him since\" -" + name); dialogueCycle = 0;
                    return;
            }
            dialogueCycle++;
        }
    }
}