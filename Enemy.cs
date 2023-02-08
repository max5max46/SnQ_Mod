using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal abstract class EnemyClass : GameCharacter
    {
        protected int moveCharge;
        protected int moveAt;



        public EnemyClass(int x, int y, int health) : base(x, y, health)
        {
            moveCharge = 0;
            color = ConsoleColor.Red;
            baseColor = color;
            attackColor = ConsoleColor.DarkBlue;
        }

        public override void Update(Render render)
        {
            base.Update(render);
            if (dead)
                return;
            moveCharge++;
            MoveAI();
        }

        protected void MoveAI()
        {

        }

        protected bool MoveChargeCheck()
        {
            if (moveCharge >= moveAt)
            {
                moveCharge = 0;
                return true;
            }
            return false;
        }

        // Movement behaviours

        protected void RandomMovement()
        {
            if (MoveChargeCheck())
                return;

            // attack the player
            int[] playerPos = GameManager.GetPlayerPos();
            if (((Math.Abs(playerPos[0] - x) == 0) && (Math.Abs(playerPos[1] - y) == 1)) || ((Math.Abs(playerPos[0] - x) == 1) && (Math.Abs(playerPos[1] - y) == 0)))
            {
                Attack();
                return;
            }

            // or move
            Random random = new Random();
            switch (random.Next(4))
            {
                case 0:
                    MoveUp();
                    break;
                case 1:
                    MoveLeft();
                    break;
                case 2:
                    MoveDown();
                    break;
                case 3:
                    MoveRight();
                    break;
            }
        }
    }
}