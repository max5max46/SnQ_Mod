using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Enemy1 : EnemyClass
    {
        public Enemy1(int x, int y) : base()
        {
            Constructor(x, y);

            character = '0';
            moveAt = 2;
        }

        protected override void MoveAI()
        {
            base.MoveAI();

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