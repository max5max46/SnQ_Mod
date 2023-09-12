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
            health = Global.QUEST_HP;
            maxHealth = Global.QUEST_HP;
            character = Global.QUEST_CHAR;
            this.Type = type;
            name = type.ToString();
        }
    }
}