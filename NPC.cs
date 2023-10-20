using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class NPC : GameCharacter
    {
        protected int dialogueCycle = 0;
        protected string[] dialogue;

        public NPC(int x, int y, Map map, AttackMap attackMap, Render render, char character, string name, string[] dialogue) : base(x, y, map, attackMap, render)
        {
            color = ConsoleColor.Green;
            baseColor = color;

            this.character = character;
            this.name = name;
            this.dialogue = dialogue;

        }

        public override void Update()
        {
            base.Update();
        }

        public void Interact()
        {
            if (dialogue.Length <= dialogueCycle)
                dialogueCycle = 0;

            GameManager.playerUI.AddEvent(dialogue[dialogueCycle] + " -" + name);
            dialogueCycle++;
        }

        protected override void Die()
        {
        }

        public override void TakeDamage(int damageAmount, bool displayDamage = true)
        {
        }

    }
}