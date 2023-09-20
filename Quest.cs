using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Quest
    {
        private Map map;
        private AttackMap attackMap;
        private Player player;
        private Render render;
        private enum QuestState
        {
            unaccepted,
            accepted,
            notTurnedIn,
            turnedIn
        }
        
        private QuestState state;

        private char character;

        private ConsoleColor color;

        private int reward;

        private int x, y;

        private bool aboutToAccept;

        private QuestTypeClass.QuestType Type;

        private string questDescription;

        public Quest(int x, int y, QuestTypeClass.QuestType Type, Render render, AttackMap attackMap, Map map, Player player, int reward)
        {
            this.x = x;
            this.y = y;
            this.Type = Type;
            this.render = render;
            this.attackMap = attackMap;
            this.map = map;
            this.player = player;
            this.reward = reward;
            
            state = QuestState.unaccepted;
            aboutToAccept = false;
            SetQuestDescription();
        }

        public void GetMap(Map map)
        {
            this.map = map;
        }
        public void GetAttackMap(AttackMap attackMap)
        {
            this.attackMap = attackMap;
        }
        public void GetPlayer(Player player)
        {
            this.player = player;
        }

        public void Draw()
        {
            if (state == QuestState.turnedIn)
                return;
            switch (state)
            {
                case QuestState.unaccepted: 
                    render.ChangeSpace(Global.UNACCEPTED_QUEST, ConsoleColor.Black, ConsoleColor.Red, x, y); return;
                case QuestState.accepted:
                    render.ChangeSpace(Global.UNACCEPTED_QUEST, ConsoleColor.Black, ConsoleColor.Yellow, x, y); return;
                case QuestState.notTurnedIn:
                    render.ChangeSpace(Global.COMPLETED_QUEST, ConsoleColor.Black, ConsoleColor.Green, x, y); return;
            }
            
        }

        public void Update()
        {
            if (state == QuestState.turnedIn)
                return;
            if (attackMap.IsAttack(x, y))
                if (attackMap.PlayerAttackCheck(x, y))
                    switch (state)
                    {
                        case QuestState.unaccepted:
                            AcceptQuest(); break;
                        case QuestState.accepted:
                            CheckQuest(); return;
                        case QuestState.notTurnedIn:
                            AcceptQuest(); return;
                    }
            aboutToAccept = false;
        }

        private void SetQuestDescription()
        {
            switch (Type)
            {
                case QuestTypeClass.QuestType.GiveHealth:
                    questDescription = "\"Could I get some blood? maybe 3 HP worth?\" -Sketchy Docter";
                    break;
                case QuestTypeClass.QuestType.GiveSpear:
                    questDescription = "\"My spear was damaged and I need a new one\" -Brash Hunter";
                    break;
            }
        }

        private void AcceptQuest()
        {
            if (aboutToAccept == true)
            {
                GameManager.playerUI.AddEvent("You accepted the Quest!");
                state = QuestState.accepted;
            }
            else
            {
                GameManager.playerUI.AddEvent(questDescription);
                GameManager.playerUI.AddEvent("Reward: " + reward + " coins");
                aboutToAccept = true;
                return;
            }
        }

        private void CheckQuest()
        {
            switch (Type)
            {
                case QuestTypeClass.QuestType.GiveHealth:
                    questDescription = "\"Could I get some blood? maybe 3 HP worth?\" -Sketchy Docter";
                    break;
                case QuestTypeClass.QuestType.GiveSpear:
                    questDescription = "\"My spear was damaged and I need a new one\" -Brash Hunter";
                    break;
            }
        }
    }
}