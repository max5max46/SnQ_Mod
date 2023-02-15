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
                case GameCharacter.CROSS_ATTACK:
                    crossAttack(x, y, currentAttack);
                    break;
                case GameCharacter.SPACE_ATTACK:
                    spaceAttack(x, y, currentAttack);
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

        // attack shapes

        private void crossAttack(int x, int y, Attack attack)
        {
            if (y != 0)
            {
                attacks[y - 1, x].isAttack = true;
                attacks[y - 1, x].strength = attack.strength;
                attacks[y - 1, x].isPlayer = attack.isPlayer;
            }
            if (y != map.map.GetLength(0) - 1)
            {
                attacks[y + 1, x].isAttack = true;
                attacks[y + 1, x].strength = attack.strength;
                attacks[y + 1, x].isPlayer = attack.isPlayer;
            }
            if (x != 0)
            {
                attacks[y, x - 1].isAttack = true;
                attacks[y, x - 1].strength = attack.strength;
                attacks[y, x - 1].isPlayer = attack.isPlayer;
            }
            if (x != map.map.GetLength(1) - 1)
            {
                attacks[y, x + 1].isAttack = true;
                attacks[y, x + 1].strength = attack.strength;
                attacks[y, x + 1].isPlayer = attack.isPlayer;
            }
        }
        private void spaceAttack(int x, int y, Attack attack)
        {
            attacks[y, x].isAttack = true;
            attacks[y, x].strength = attack.strength;
            attacks[y, x].isPlayer = attack.isPlayer;
        }
    }
}