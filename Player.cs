using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Player : GameCharacter
    {
        public Player(int x, int y, int health, Map map, AttackMap attackMap, Render render) : base(x, y, health, map, attackMap, render)
        {
            character = '@';
            color = ConsoleColor.White;
            attackColor = ConsoleColor.Magenta;
            baseColor = color;
            attackShape = GameCharacter.CROSS_ATTACK;
            kamikaze = false;
            strength = 1;
            name = "player";
        }

        public override void Update()
        {
            base.Update();
            if (dead)
                return;

            DetectInput();
        }

        protected void DetectInput()
        {
            switch (GameManager.pressedKey)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
                case ConsoleKey.Spacebar:
                    Attack(attackShape);
                    break;
            }
        }

        public void CheckForDeath()
        {
            if (!dead && attackMap.IsAttack(x, y))
            {
                health -= attackMap.AttackStrength(x, y);
                if (health <= 0)
                {
                    dead = true;
                }
            }
        }
    }
}