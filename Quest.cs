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

        public void Draw()
        {
            if (state == QuestState.turnedIn)
                return;
            switch (state)
            {
                case QuestState.unaccepted: 
                    render.ChangeSpace(Global.UNACCEPTED_QUEST, ConsoleColor.Black, ConsoleColor.Red, x, y); return;
                case QuestState.accepted:
                    render.ChangeSpace(Global.ACCEPTED_QUEST, ConsoleColor.Black, ConsoleColor.Yellow, x, y); return;
                case QuestState.notTurnedIn:
                    render.ChangeSpace(Global.NOT_TURNED_IN_QUEST, ConsoleColor.Black, ConsoleColor.Green, x, y); return;
            }
            
        }

        public void Update()
        {
            if (state == QuestState.turnedIn)
                return;
            if (state == QuestState.accepted || state == QuestState.notTurnedIn)
                UpdateQuest();
            if (attackMap.IsAttack(x, y))
                if (attackMap.PlayerAttackCheck(x, y))
                    switch (state)
                    {
                        case QuestState.unaccepted:
                            AcceptQuest(); return;
                        case QuestState.accepted:
                            CheckQuest(); break;
                        case QuestState.notTurnedIn:
                            TurnInQuest(); break;
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
                case QuestTypeClass.QuestType.GiveHula:
                    questDescription = "\"Mom won't buy me have a hula-hoop, could someone get me one?\" -Demanding Kid";
                    break;
            }
        }

        private void AcceptQuest()
        {
            if (aboutToAccept == true)
            {
                GameManager.playerUI.AddEvent("You accepted the Quest!");
                state = QuestState.accepted;
                UpdateQuest();
            }
            else
            {
                GameManager.playerUI.AddEvent(questDescription);
                GameManager.playerUI.AddEvent("Reward: " + reward + " coins   (unaccepted)");
                aboutToAccept = true;
                return;
            }
        }

        private void TurnInQuest()
        {
            switch (Type)
            {
                case QuestTypeClass.QuestType.GiveHealth:
                    player.TakeDamage(3);
                    break;
                case QuestTypeClass.QuestType.GiveSpear:
                    player.ChangeAttackShape(Global.CROSS_ATTACK);
                    GameManager.playerUI.AddEvent("player lost the spear!");
                    break;
                case QuestTypeClass.QuestType.GiveHula:
                    player.ChangeAttackShape(Global.CROSS_ATTACK);
                    GameManager.playerUI.AddEvent("player lost the hula-hoop!");
                    break;
            }

            state = QuestState.turnedIn;
            player.GiveCoins(reward);
            GameManager.playerUI.AddEvent("Quest Complete! You got " + reward + " coins!");
        }

        private void UpdateQuest()
        {
            switch (Type)
            {
                case QuestTypeClass.QuestType.GiveHealth:
                    if (player.GetHealth() > 3)
                        state = QuestState.notTurnedIn;
                    else
                        state = QuestState.accepted;
                    break;
                case QuestTypeClass.QuestType.GiveSpear:
                    if (player.GetAttackShape() == Global.LONG_ATTACK)
                        state = QuestState.notTurnedIn;
                    else
                        state = QuestState.accepted;
                    break;
                case QuestTypeClass.QuestType.GiveHula:
                    if (player.GetAttackShape() == Global.RING_ATTACK)
                        state = QuestState.notTurnedIn;
                    else
                        state = QuestState.accepted;
                    break;
            }
        }

        private void CheckQuest()
        {
            SetQuestDescription();
            GameManager.playerUI.AddEvent(questDescription);
            GameManager.playerUI.AddEvent("Reward: " + reward + " coins   (In Progress)");
        }
    }
}