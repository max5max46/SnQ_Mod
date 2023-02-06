using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Enemy1 : EnemyClass
    {
        public Enemy1(int x, int y, int health) : base(x, y, health)
        {
            this.health = health;

            character = '0';
            moveAt = 2;
        }

        protected override void MoveAI()
        {
            if (MoveChargeCheck())
                return;

            // attack the player
            int[] playerPos = Program.GetPlayerPos();
            if (((Math.Abs(playerPos[0] - x) == 0) && (Math.Abs(playerPos[1] - y) == 1)) || ((Math.Abs(playerPos[0] - x) == 1) && (Math.Abs(playerPos[1] - y) == 0)))
            {
                Attack();
                return;
            }

            // or move
            Random random = new Random();
            switch(random.Next(4))
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