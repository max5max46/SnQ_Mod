using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Elite : Enemy
    {
        public Elite(int x, int y, Map map, AttackMap attackMap, Render render, EnemyTypeClass.EnemyType type) : base(x, y, map, attackMap, render)
        {
            health = Global.ELITE_HP;
            maxHealth = Global.ELITE_HP;
            moveAt = Global.ELITE_MOVEAT;
            character = Global.ELITE_CHAR;
            strength = Global.ELITE_STRENGTH;
            attackShape = Global.LONG_ATTACK;
            this.Type = type;
            name = type.ToString();
        }

        protected override void MoveAI()
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
    }
}
