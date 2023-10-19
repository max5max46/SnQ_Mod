using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Charger : Enemy
    {
        public Charger(int x, int y, Map map, AttackMap attackMap, Render render, EnemyTypeClass.EnemyType type) : base(x, y, map, attackMap, render)
        {
            health = Global.CHARGER_HP;
            maxHealth = Global.CHARGER_HP;
            moveAt = Global.CHARGER_MOVEAT;
            character = Global.CHARGER_CHAR;
            strength = Global.CHARGER_STRENGTH;
            attackShape = Global.SPACE_ATTACK;
            this.type = type;
            name = type.ToString();
            kamikaze = true;
        }

        protected override void MoveAI()
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
    }
}