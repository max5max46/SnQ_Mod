using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Player : GameCharacter
    {
        public Player(int x, int y, int health) : base(x, y, health)
        {
            character = '@';
            color = ConsoleColor.White;
            attackColor = ConsoleColor.Magenta;
            baseColor = color;
        }

        public override void Update(Render render)
        {
            base.Update(render);
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
                    Attack();
                    break;
            }
        }

        public void CheckForDeath()
        {
            if (!dead && attackMap.IsAttack(x, y))
            {
                health--;
                if (health <= 0)
                {
                    dead = true;
                }
            }
        }
    }
}