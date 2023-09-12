using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class NPCTypeClass
    {
        public enum NPCType
        {
            ShopKeep,
            QuestDealer,
            Sign
        }

        public static NPC CreateNPC(NPCType npcType, int x, int y, Map map, AttackMap attackMap, Render render)
        {
            switch (npcType)
            {
                case NPCType.ShopKeep:
                    return new ShopKeep(x, y, map, attackMap, render, NPCType.ShopKeep);
                case NPCType.QuestDealer:
                    return new QuestDealer(x, y, map, attackMap, render, NPCType.QuestDealer);
                case NPCType.Sign:
                    return new Sign(x, y, map, attackMap, render, NPCType.Sign);
                default: return null;
            }
        }
    }
}