using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class EnemyClass : GameCharacter
    {
        // movement behaviour constants
        public const int BEHAVIOUR_RANDOM = 0;
        public const int BEHAVIOUR_CHASE = 1;

        private int moveCharge;
        private int moveAt;
        private int moveBehaviour;

        public EnemyClass(int x, int y, int health, int moveAt, int moveBehaviour, char character) : base(x, y, health)
        {
            moveCharge = 0;
            color = ConsoleColor.Red;
            baseColor = color;
            attackColor = ConsoleColor.DarkBlue;
            this.moveAt = moveAt;
            this.moveBehaviour = moveBehaviour;
            this.character = character;
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
            switch (moveBehaviour)
            {
                case BEHAVIOUR_RANDOM:
                    RandomMovement();
                    break;
                case BEHAVIOUR_CHASE:
                    ChaseMovement();
                    break;
                default:
                    break;
            }
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
            if (!MoveChargeCheck())
                return;

            // attack the player
            int[] playerPos = GameManager.GetPlayerPos();
            if (((Math.Abs(playerPos[0] - x) == 0) && (Math.Abs(playerPos[1] - y) == 1)) || ((Math.Abs(playerPos[0] - x) == 1) && (Math.Abs(playerPos[1] - y) == 0)))
            {
                Attack(CROSS_ATTACK);
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

        protected void ChaseMovement()
        {
            if (!MoveChargeCheck())
                return;

            // attack the player
            int[] playerPos = GameManager.GetPlayerPos();
            if (x == playerPos[0] && y == playerPos[1])
            {
                Attack(SPACE_ATTACK);
                dead = true;
                return;
            }

            // or move
            if (playerPos[0] > x)
                MoveRight();
            else if (playerPos[0] < x)
                MoveLeft();
            else if (playerPos[1] > y)
                MoveDown();
            else if (playerPos[1] < y)
                MoveUp();
        }
    }
}