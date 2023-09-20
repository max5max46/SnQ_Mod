using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class QuestTypeClass
    {
        public enum QuestType
        {
            GiveHealth,
            GiveSpear
        }

        public static Quest CreateQuest(QuestType questType, int x, int y, Render render, AttackMap attackMap, Map map, Player player, int cost)
        {
            switch (itemType)
            {
                case ItemType.GiveHealth:
                    return new Item(Global.HEALTH_CHAR, ConsoleColor.Magenta, x, y, itemType, render, attackMap, map, player, "health pickup", cost);
                case ItemType.GiveSpear:
                    return new Item(Global.HEALTH_CHAR2, ConsoleColor.Red, x, y, itemType, render, attackMap, map, player, "large health pickup", cost);
                default:
                    return new Item(Global.HEALTH_CHAR, ConsoleColor.Magenta, x, y, itemType, render, attackMap, map, player, "health pickup", cost);
            }
        }
    }
}