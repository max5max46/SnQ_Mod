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
        public const int LONG_ATTACK = 2;
        public const int RING_ATTACK = 3;
        public const int X_ATTACK = 4;

        protected Map map;
        protected AttackMap attackMap;
        protected Render render;

        protected char character;

        protected ConsoleColor color, attackColor, baseColor;

        protected int x, y;
        protected int attackShape;
        protected int health;
        protected int maxHealth;
        protected int strength;

        protected bool dead;
        protected bool kamikaze;

        protected string name;

        public GameCharacter(int x, int y, int health, Map map, AttackMap attackMap, Render render)
        {
            this.x = x;
            this.y = y;
            this.health = health;
            this.maxHealth = health;
            this.map = map;
            this.attackMap = attackMap;
            this.render = render;

            dead = false;
        }

        public void Draw()
        {
            render.ChangeSpace(character, ConsoleColor.Black, color, x, y);

            color = baseColor; // returns color to normal after attacking
        }

        public virtual void Update()
        {
            if (!dead && attackMap.IsAttack(x, y))
                TakeDamage(attackMap.AttackStrength(x, y));
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
            attackMap.AddAttack(x, y, strength, attackShape, name);
            if (kamikaze)
                Die();
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

        public void ChangeAttackShape(int newShape)
        {
            attackShape = newShape;
        }

        public void Heal(int healAmount)
        {
            health += healAmount;
            if (health > maxHealth)
                health = maxHealth;
        }

        public void TakeDamage(int damageAmount)
        {
            health -= damageAmount;
            if (health <= 0)
                Die();
        }
    }
}