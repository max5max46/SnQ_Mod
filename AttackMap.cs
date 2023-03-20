using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class AttackMap
    {
        Map map;
        Render render;

        struct Attack
        {
            public bool isAttack;
            public int strength;
            public bool isPlayer;
        }

        Attack[,] attacks;

        public AttackMap(Map map, Render render)
        {
            this.map = map;
            this.render = render;
            attacks = new Attack[map.map.GetLength(0), map.map.GetLength(1)];
        }

        public void AddAttack(int x, int y, int strength, int attackShape, string source)
        {
            Attack currentAttack = new Attack();
            currentAttack.strength = strength;
            if (source == "player")
                currentAttack.isPlayer = true;

            switch (attackShape)
            {
                case Global.CROSS_ATTACK:
                    crossAttack(x, y, currentAttack);
                    break;
                case Global.SPACE_ATTACK:
                    spaceAttack(x, y, currentAttack);
                    break;
                case Global.LONG_ATTACK:
                    longAttack(x, y, currentAttack);
                    break;
                case Global.RING_ATTACK:
                    ringAttack(x, y, currentAttack);
                    break;
                case Global.X_ATTACK:
                    xAttack(x, y, currentAttack);
                    break;
                default:
                    break;
            }
        }

        public bool IsAttack(int x, int y)
        {
            return attacks[y, x].isAttack;
        }
        public int AttackStrength(int x, int y)
        {
            return attacks[y, x].strength;
        }

        public bool PlayerAttackCheck(int x, int y)
        {
            return attacks[y, x].isPlayer;
        }

        public void Update()
        {
            for (int i = 0; i < attacks.GetLength(0); i++)
                for (int j = 0; j < attacks.GetLength(1); j++)
                    attacks[i, j].isAttack = false;
        }

        public void Draw()
        {
            for (int i = 0; i < attacks.GetLength(0); i++)
            {
                for (int j = 0; j < attacks.GetLength(1); j++)
                {
                    if (attacks[i, j].isAttack == true)
                    {
                        render.ChangeSpace('.', ConsoleColor.DarkRed, ConsoleColor.DarkRed, j, i);
                    }
                }
            } 
        }

        public void Flash()
        {
            for (int i = 0; i < attacks.GetLength(0); i++)
            {
                for (int j = 0; j < attacks.GetLength(1); j++)
                {
                    AddAttack(j, i, 0, Global.SPACE_ATTACK, "bomb");
                }
            }
        }

        // attack shapes

        private void crossAttack(int x, int y, Attack attack)
        {
            if (y != 0)
            {
                attacks[y - 1, x] = attack;
                attacks[y - 1, x].isAttack = true;
            }
            if (y != map.map.GetLength(0) - 1)
            {
                attacks[y + 1, x] = attack;
                attacks[y + 1, x].isAttack = true;
            }
            if (x != 0)
            {
                attacks[y, x - 1] = attack;
                attacks[y, x - 1].isAttack = true;
            }
                
            if (x != map.map.GetLength(1) - 1)
            {
                attacks[y, x + 1] = attack;
                attacks[y, x + 1].isAttack = true;
            }
        }
        private void xAttack(int x, int y, Attack attack)
        {
            if (y != 0 || x != 0)
            {
                attacks[y - 1, x - 1] = attack;
                attacks[y - 1, x - 1].isAttack = true;
            }
            if (y != map.map.GetLength(0) - 1 || x != 0)
            {
                attacks[y + 1, x - 1] = attack;
                attacks[y + 1, x - 1].isAttack = true;
            }
            if (y != 0 || x != map.map.GetLength(1) - 1)
            {
                attacks[y - 1, x + 1] = attack;
                attacks[y - 1, x + 1].isAttack = true;
            }

            if (y != map.map.GetLength(0) - 1 || x != map.map.GetLength(1) - 1)
            {
                attacks[y + 1, x + 1] = attack;
                attacks[y + 1, x + 1].isAttack = true;
            }
        }
        private void spaceAttack(int x, int y, Attack attack)
        {
            attacks[y, x] = attack;
            attacks[y, x].isAttack = true;
        }

        private void longAttack(int x, int y, Attack attack)
        {
            crossAttack(x, y, attack);
            if (y != 0 && y != 1)
            {
                attacks[y - 2, x] = attack;
                attacks[y - 2, x].isAttack = true;
            }
            if (y != map.map.GetLength(0) - 1 && y != map.map.GetLength(0) - 2)
            {
                attacks[y + 2, x] = attack;
                attacks[y + 2, x].isAttack = true;
            }
            if (x != 0 && x != 1)
            {
                attacks[y, x - 2] = attack;
                attacks[y, x - 2].isAttack = true;
            }

            if (x != map.map.GetLength(1) - 1 && x != map.map.GetLength(1) - 2)
            {
                attacks[y, x + 2] = attack;
                attacks[y, x + 2].isAttack = true;
            }
        }

        private void ringAttack(int x, int y, Attack attack)
        {
            crossAttack(x, y, attack);
            xAttack(x, y, attack);
        }
    }
}