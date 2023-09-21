using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Text_Based_RPG
{
    internal class QuestManager
    {
        List<Quest> Quests = new List<Quest>();

        Render render;
        AttackMap attackMap;
        Map map;
        Player player;

        public QuestManager(Render render, AttackMap attackMap, Map map, Player player)
        {
            this.render = render;
            this.attackMap = attackMap;
            this.map = map;
            this.player = player;
        }

        public void AddQuest(QuestTypeClass.QuestType type, int x, int y, int reward)
        {
            Quests.Add(QuestTypeClass.CreateQuest(type, x, y, render, attackMap, map, player, reward));
        }

        public void Update()
        {
            foreach (Quest quest in Quests)
                quest.Update();
        }

        public void Draw()
        {
            foreach (Quest quest in Quests)
                quest.Draw();
        }

        public void InitQuests()
        {
            string[] mapString = File.ReadAllLines("Quests.txt");
            char[,] questMap = new char[mapString.GetLength(0), mapString[0].Length];

            for (int i = 0; i < mapString.GetLength(0); i++)
                for (int j = 0; j < mapString[0].Length; j++)
                    questMap[i, j] = mapString[i][j];

            for (int i = 0; i < questMap.GetLength(0); i++)
                for (int j = 0; j < questMap.GetLength(1); j++)
                {
                    switch (questMap[i, j])
                    {
                        case Global.RANDOM_QUEST_CHAR:
                            switch (Global.random.Next(3))
                            {
                                case 0:
                                    AddQuest(QuestTypeClass.QuestType.GiveHealth, j, i, Global.random.Next(Global.GIVE_HEALTH_QUEST_REWARD_RANGE) + Global.GIVE_HEALTH_QUEST_REWARD_MIN);
                                    break;
                                case 1:
                                    AddQuest(QuestTypeClass.QuestType.GiveSpear, j, i, Global.random.Next(Global.GIVE_SPEAR_QUEST_REWARD_RANGE) + Global.GIVE_SPEAR_QUEST_REWARD_MIN);
                                    break;
                                case 2:
                                    AddQuest(QuestTypeClass.QuestType.GiveHula, j, i, Global.random.Next(Global.GIVE_HULA_QUEST_REWARD_RANGE) + Global.GIVE_HULA_QUEST_REWARD_MIN);
                                    break;
                            }
                            break;
                        case Global.GIVE_HEALTH_QUEST_CHAR:
                            AddQuest(QuestTypeClass.QuestType.GiveHealth, j, i, Global.random.Next(Global.GIVE_HEALTH_QUEST_REWARD_RANGE) + Global.GIVE_HEALTH_QUEST_REWARD_MIN);
                            break;
                        case Global.GIVE_SPEAR_QUEST_CHAR:
                            AddQuest(QuestTypeClass.QuestType.GiveSpear, j, i, Global.random.Next(Global.GIVE_SPEAR_QUEST_REWARD_RANGE) + Global.GIVE_SPEAR_QUEST_REWARD_MIN);
                            break;
                        case Global.GIVE_HULA_QUEST_CHAR:
                            AddQuest(QuestTypeClass.QuestType.GiveHula, j, i, Global.random.Next(Global.GIVE_HULA_QUEST_REWARD_RANGE) + Global.GIVE_HULA_QUEST_REWARD_MIN);
                            break;
                    }
                }
        }
    }
}