using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Enemy : GameCharacter
    {
        // movement behaviour constants
        public const int BEHAVIOUR_RANDOM = 0;
        public const int BEHAVIOUR_CHASE = 1;
        public const int BEHAVIOUR_LAVA = 2;

        private int moveCharge;
        private int moveAt;
        private int moveBehaviour;
        private int range;

        public Enemy(int x, int y, int health, int moveAt, int strength, int moveBehaviour, int attackShape, char character, bool kamikaze, string name, Map map, AttackMap attackMap, Render render, int range = 0) : base(x, y, health, map, attackMap, render)
        {
            moveCharge = 0;
            color = ConsoleColor.Red;
            baseColor = color;
            attackColor = ConsoleColor.DarkBlue;
            this.moveAt = moveAt;
            this.moveBehaviour = moveBehaviour;
            this.character = character;
            this.attackShape = attackShape;
            this.kamikaze = kamikaze;
            this.name = name;
            this.strength = strength;
            this.range = range;
        }

        public override void Update()
        {
            base.Update();
            if (dead)
                return;
            moveCharge++;
            MoveAI();
        }

        private void MoveAI()
        {
            switch (moveBehaviour)
            {
                case BEHAVIOUR_RANDOM:
                    RandomMovement();
                    break;
                case BEHAVIOUR_CHASE:
                    ChaseMovement();
                    break;
                case BEHAVIOUR_LAVA:
                    Attack(attackShape);
                    break;
                default:
                    break;
            }
        }

        private bool MoveChargeCheck()
        {
            if (moveCharge >= moveAt)
            {
                moveCharge = 0;
                return true;
            }
            return false;
        }

        protected override void Die()
        {
            base.Die();
        }

        // Behaviours -----------------------------------------------------------------------------------------------------------------------------------------------------

        private void RandomMovement()
        {
            if (!MoveChargeCheck())
                return;

            // attack the player
            int[] playerPos = GameManager.GetPlayerPos();
            if (((Math.Abs(playerPos[0] - x) == 0) && (Math.Abs(playerPos[1] - y) == 1)) || ((Math.Abs(playerPos[0] - x) == 1) && (Math.Abs(playerPos[1] - y) == 0)))
            {
                Attack(attackShape);
                return;
            }

            // or move
            switch (GameManager.random.Next(4))
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

        private void ChaseMovement()
        {
            if (!MoveChargeCheck())
                return;

            // attack the player
            int[] playerPos = GameManager.GetPlayerPos();
            if (x == playerPos[0] && y == playerPos[1])
            {
                Attack(attackShape);
                return;
            }

            // or move
            if (playerPos[0] > x)
            {
                if (MoveRight())
                {
                    if (playerPos[1] > x)
                        MoveDown();
                    else if (playerPos[1] < y)
                        MoveUp();
                }
            }
            else if (playerPos[0] < x)
            {
                if (MoveLeft())
                {
                    if (playerPos[1] > x)
                        MoveDown();
                    else if (playerPos[1] < y)
                        MoveUp();
                }
            }
            else if (playerPos[1] > y)
                MoveDown();
            else if (playerPos[1] < y)
                MoveUp();
        }
    }
}