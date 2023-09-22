using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Gambler : NPC
    {
        public Gambler(int x, int y, Map map, AttackMap attackMap, Render render, NPCTypeClass.NPCType type) : base(x, y, map, attackMap, render)
        {
            health = 1;
            maxHealth = 1;
            dialogueCycle = 0;
            character = Global.GAMBLER_CHAR;
            this.Type = type;
            name = "Gambler";
        }
        public override void Interact()
        {
            switch (dialogueCycle)
            {
                case 0:
                    GameManager.playerUI.AddEvent("\"Hello there old boy! Here to try your luck?\" -" + name);
                    break;
                case 1:
                    GameManager.playerUI.AddEvent("\"Buy a bag and you may get your coins back and then some!\" -" + name);
                    break;
                case 2:
                    GameManager.playerUI.AddEvent("\"Gem? of course! you can afford as many gems as you want, just play my game!\" -" + name); dialogueCycle = 0;
                    return;
            }
            dialogueCycle++;
        }
    }
}