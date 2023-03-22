using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Lava : Enemy
    {
        public Lava(int x, int y, Map map, AttackMap attackMap, Render render, EnemyTypeClass.EnemyType type) : base(x, y, map, attackMap, render)
        {
            health = Global.LAVA_HP;
            maxHealth = Global.LAVA_HP;
            moveAt = Global.LAVA_MOVEAT;
            character = Global.LAVA_CHAR;
            strength = Global.LAVA_STRENGTH;
            attackShape = Global.RING_ATTACK;
            this.type = type;
            name = type.ToString();
        }

        protected override void MoveAI()
        {
            Attack(attackShape);
        }
    }
}