using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Journal : NPC
    {
        public Journal(int x, int y, Map map, AttackMap attackMap, Render render, NPCTypeClass.NPCType type) : base(x, y, map, attackMap, render)
        {
            health = 1;
            maxHealth = 1;
            dialogueCycle = 0;
            character = Global.JOURNAL_CHAR;
            this.Type = type;
            name = "Journal";
        }
        public override void Interact()
        {
            switch (dialogueCycle)
            {
                case 0:
                    GameManager.playerUI.AddEvent("\"Day XXX: Ever since I heard the legend of the old hero, I've been training for a great quest!\" -" + name);
                    break;
                case 1:
                    GameManager.playerUI.AddEvent("\"Day XZX: Finally a lead to begin my quest! but to pursue it I need an gem...\" -" + name);
                    break;
                case 2:
                    GameManager.playerUI.AddEvent("\"Day XYZ: Given the research I've done, there should be someone in this town who has one, time to ask around\" -" + name); dialogueCycle = 0;
                    return;
            }
            dialogueCycle++;
        }
    }
}