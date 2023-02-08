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
    }
}