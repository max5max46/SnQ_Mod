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

        public void Constructor(int x, int y)
        {
            this.x = x;
            this.y = y;
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

        protected abstract void MoveAI();

        protected bool MoveChargeCheck()
        {
            if (moveCharge >= moveAt)
            {
                moveCharge = 0;
                return true;
            }
            return false;
        }
    }
}