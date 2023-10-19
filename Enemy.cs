using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Enemy : GameCharacter
    {
        protected int moveCharge;
        protected int moveAt;
        protected string moveType;

        public Enemy(int x, int y, Map map, AttackMap attackMap, Render render, int maxHealth, int moveAt, char character, int strength, string attackShape, bool kamikaze, string moveType, string name) : base(x, y, map, attackMap, render)
        {
            moveCharge = 0;
            color = ConsoleColor.Red;
            baseColor = color;
            attackColor = ConsoleColor.DarkBlue;

            this.maxHealth = maxHealth;
            health = this.maxHealth;
            this.moveAt = moveAt;
            this.character = character;
            this.strength = strength;
            this.attackShape = Global.ConvertAttackType(attackShape);
            this.kamikaze = true;
            this.moveType = moveType;
            this.name = name;
        }

        public override void Update()
        {
            base.Update();
            if (dead)
                return;
            moveCharge++;
            if (!MoveChargeCheck())
                return;
            MoveAI();
        }

        protected void MoveAI()
        {
            switch (moveType)
            {
                case "chasing": ChasingMove(); break;
                case "random": RandomMove(); break;
                case "random_long": RandomMoveL(); break;
                case "static": StaticMove(); break;
            }
            return;
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

        private void ChasingMove()
        {
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
                xDelta++;
                if (Move())
                {
                    if (playerPos[1] > x)
                        yDelta++;
                    else if (playerPos[1] < y)
                        yDelta--;
                }
            }
            else if (playerPos[0] < x)
            {
                xDelta--;
                if (Move())
                {
                    if (playerPos[1] > x)
                        yDelta++;
                    else if (playerPos[1] < y)
                        yDelta--;
                }
            }
            else if (playerPos[1] > y)
                yDelta++;
            else if (playerPos[1] < y)
                yDelta--;

            Move();
        }

        private void RandomMove()
        {
            // attack the player
            int[] playerPos = GameManager.GetPlayerPos();
            if (((Math.Abs(playerPos[0] - x) == 0) && (Math.Abs(playerPos[1] - y) == 1)) || ((Math.Abs(playerPos[0] - x) == 1) && (Math.Abs(playerPos[1] - y) == 0)))
            {
                Attack(attackShape);
                return;
            }

            // or move
            switch (Global.random.Next(4))
            {
                case 0:
                    yDelta--;
                    break;
                case 1:
                    xDelta--;
                    break;
                case 2:
                    yDelta++;
                    break;
                case 3:
                    xDelta++;
                    break;
            }
            Move();
        }

        private void RandomMoveL()
        {
            // attack the player
            int[] playerPos = GameManager.GetPlayerPos();
            if (
                ((Math.Abs(playerPos[0] - x) == 0) && (Math.Abs(playerPos[1] - y) == 1)) ||
                ((Math.Abs(playerPos[0] - x) == 1) && (Math.Abs(playerPos[1] - y) == 0)) ||
                ((Math.Abs(playerPos[0] - x) == 0) && (Math.Abs(playerPos[1] - y) == 2)) ||
                ((Math.Abs(playerPos[0] - x) == 2) && (Math.Abs(playerPos[1] - y) == 0)))
            {
                Attack(attackShape);
                return;
            }

            // or move
            switch (Global.random.Next(4))
            {
                case 0:
                    yDelta--;
                    break;
                case 1:
                    xDelta--;
                    break;
                case 2:
                    yDelta++;
                    break;
                case 3:
                    xDelta++;
                    break;
            }
            Move();
        }

        private void StaticMove()
        {
            // attack
            Attack(attackShape);
        }

        protected override void Die()
        {
            base.Die();
        }

        public override void TakeDamage(int damageAmount, bool displayDamage = true)
        {
            if (attackMap.PlayerAttackCheck(x, y)) base.TakeDamage(damageAmount, displayDamage);
        }
        public void TakeDamageDirect(int damageAmount, bool displayDamage = true)
        {
            base.TakeDamage(damageAmount, displayDamage);
        }

        public string GetEnemyName()
        {
            return name;
        }
    }
}