﻿using System;
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

        public override void TakeDamage(int damageAmount, bool displayDamage = true)
        {
            switch (health)
            {
                case 3:
                    GameManager.playerUI.AddEvent("\"Hey! Watch where you swing that thing!\" -" + name);
                    break;
                case 2:
                    GameManager.playerUI.AddEvent("\"I'm serious! get away from me with that thing!\" -" + name);
                    break;
                case 1:
                    GameManager.playerUI.AddEvent("\"Why....\" -" + name);
                    break;
            }

            base.TakeDamage(damageAmount);
        }
    }
}