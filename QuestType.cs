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

        public static Quest CreateQuest(QuestType questType, int x, int y, Render render, AttackMap attackMap, Map map, Player player, int reward)
        {
            switch (questType)
            {
                case QuestType.GiveHealth:
                    return new Quest(x, y, questType, render, attackMap, map, player, reward);
                case QuestType.GiveSpear:
                    return new Quest(x, y, questType, render, attackMap, map, player, reward);
                default:
                    return new Quest(x, y, questType, render, attackMap, map, player, reward);
            }
        }
    }
}