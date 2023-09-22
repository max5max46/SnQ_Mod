using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class QuestDealer : NPC
    {
        public QuestDealer(int x, int y, Map map, AttackMap attackMap, Render render, NPCTypeClass.NPCType type) : base(x, y, map, attackMap, render)
        {
            health = 1;
            maxHealth = 1;
            dialogueCycle = 0;
            character = Global.QUEST_CHAR;
            this.Type = type;
            name = "Quest Manager";
        }

        public override void Interact()
        {
            switch (dialogueCycle)
            {
                case 0:
                    GameManager.playerUI.AddEvent("\"Oh! Hi! Didn't see you there, feel free to take a quest!\" -" + name);
                    break;
                case 1:
                    GameManager.playerUI.AddEvent("\"What? a gem you say? I heard the Mayor might have one\" -" + name); dialogueCycle = 0;
                    return;
            }
            dialogueCycle++;
        }
    }
}