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
        Render render;

        public AttackMap(Map map, Render render)
        {
            this.map = map;
            this.render = render;
            attacks = new bool[map.map.GetLength(0), map.map.GetLength(1)];
        }

        public void AddAttack(int x, int y, int attackShape)
        {
            switch (attackShape)
            {
                case 0:
                    crossAttack(x, y);
                    break;
                case 1:
                    spaceAttack(x, y);
                    break;
                default:
                    break;
            }
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

        public void Draw()
        {
            for (int i = 0; i < attacks.GetLength(0); i++)
            {
                for (int j = 0; j < attacks.GetLength(1); j++)
                {
                    if (attacks[i, j] == true)
                    {
                        render.ChangeSpace('.', ConsoleColor.DarkRed, ConsoleColor.DarkRed, j, i);
                    }
                }
            } 
        }

        // attack shapes

        private void crossAttack(int x, int y)
        {
            if (y != 0)
                attacks[y - 1, x] = true;
            if (y != map.map.GetLength(0) - 1)
                attacks[y + 1, x] = true;
            if (x != 0)
                attacks[y, x - 1] = true;
            if (x != map.map.GetLength(1) - 1)
                attacks[y, x + 1] = true;
        }
        private void spaceAttack(int x, int y)
        {
            attacks[y, x] = true;
        }
    }
}