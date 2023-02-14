using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal abstract class GameCharacter
    {
        // attack shape constants
        public const int CROSS_ATTACK = 0;
        public const int SPACE_ATTACK = 1;

        protected Map map;
        protected AttackMap attackMap;

        protected char character;

        protected ConsoleColor color, attackColor, baseColor;

        protected int x, y;
        protected int attackShape;
        protected int health;

        protected bool dead;
        protected bool kamikaze;

        public GameCharacter(int x, int y, int health)
        {
            this.x = x;
            this.y = y;
            this.health = health;
            dead = false;
        }

        public void GetMap(Map map)
        {
            this.map = map;
        }
        public void GetAttackMap(AttackMap attackMap)
        {
            this.attackMap = attackMap;
        }

        public void Draw(Render render)
        {
            render.ChangeSpace(character, ConsoleColor.Black, color, x, y);

            color = baseColor; // returns color to normal after attacking
        }

        public virtual void Update(Render render)
        {
            if (!dead && attackMap.IsAttack(x, y))
            {
                health--;
                if (health <= 0)
                {
                    Die();
                }
            }
        }

        protected bool MoveUp()
        {
            if (!map.IsWall(x, y - 1))
            {
                y -= 1;
                return false;
            }
            return map.IsWall(x, y - 1);
        }
        protected bool MoveDown()
        {
            if (!map.IsWall(x, y + 1))
            {
                y += 1;
                return false;
            }
            return map.IsWall(x, y + 1);
        }
        protected bool MoveLeft()
        {
            if (!map.IsWall(x - 1, y))
            {
                x -= 1;
                return false;
            }
            return map.IsWall(x - 1, y);
        }
        protected bool MoveRight()
        {
            if (!map.IsWall(x + 1, y))
            {
                x += 1;
                return false;
            }
            return map.IsWall(x - 1, y);
        }

        protected void Attack(int attackShape)
        {
            color = attackColor;
            attackMap.AddAttack(x, y, attackShape);
            if (kamikaze)
                Die(); ;
        }

        public int[] GetPos()
        {
            return new int[] { x, y };
        }
        public bool GetDead()
        {
            return dead;
        }
        public int GetHealth()
        {
            return health;
        }

        protected virtual void Die()
        {
            dead = true;
        }
    }
}