using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class AttackMap
    {
        bool[,] attacks;

        Map map;

        public AttackMap(Map map)
        {
            this.map = map;
            attacks = new bool[map.map.GetLength(0), map.map.GetLength(1)];
        }

        public void AddAttack(int x, int y)
        {
            attacks[y + 1, x] = true;
            attacks[y - 1, x] = true;
            attacks[y, x + 1] = true;
            attacks[y, x - 1] = true;
        }

        public bool IsAttack(int x, int y)
        {
            return attacks[y, x];
        }

        public void Update()
        {
            for (int i = 0; i < attacks.GetLength(0); i++)
                for (int j = 0; j < attacks.GetLength(1); j++)
                    attacks[i, j] = false;
        }
    }
}