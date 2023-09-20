using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal abstract class GameCharacter
    {
        protected Map map;
        protected AttackMap attackMap;
        protected Render render;

        protected char character;

        protected ConsoleColor color, attackColor, baseColor;

        protected int x, y;
        protected int xDelta, yDelta;
        protected int attackShape;
        protected int health;
        protected int maxHealth;
        protected int strength;

        protected bool dead;
        protected bool kamikaze;
        protected bool waterWalking;

        protected string name;

        public GameCharacter(int x, int y, Map map, AttackMap attackMap, Render render)
        {
            this.x = x;
            this.y = y;
            this.map = map;
            this.attackMap = attackMap;
            this.render = render;

            dead = false;
        }

        public void Draw()
        {
            if (dead) return;
            render.ChangeSpace(character, ConsoleColor.Black, color, x, y);

            color = baseColor; // returns color to normal after attacking
        }

        public virtual void Update()
        {
            xDelta = 0;
            yDelta = 0;

            if (!dead && attackMap.IsAttack(x, y) && !attackMap.PlayerAttackCheck(x, y))
                TakeDamage(attackMap.AttackStrength(x, y));
        }

        protected bool Move()
        {
            if (xDelta > 0)
            {
                if (!map.IsWall(x + 1, y, waterWalking))
                {
                    x += 1;
                    xDelta = 0;
                    yDelta = 0;
                    return false;
                }
            }
            else if (xDelta < 0)
            {
                if (!map.IsWall(x - 1, y, waterWalking))
                {
                    x -= 1;
                    xDelta = 0;
                    yDelta = 0;
                    return false;
                }
            }
            else if (yDelta > 0)
            {
                if (!map.IsWall(x, y + 1, waterWalking))
                {
                    y += 1;
                    xDelta = 0;
                    yDelta = 0;
                    return false;
                }
            }
            else if (yDelta < 0)
            {
                if (!map.IsWall(x, y - 1, waterWalking))
                {
                    y -= 1;
                    xDelta = 0;
                    yDelta = 0;
                    return false;
                }
            }
            xDelta = 0;
            yDelta = 0;
            return true;
        }

        protected virtual void Attack(int attackShape)
        {
            if (name != "Lava")
                GameManager.playerUI.AddEvent(name + " attacked!");
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
            GameManager.playerUI.AddEvent(name + " died!");
            dead = true;
        }

        public int GetAttackShape()
        {
            return attackShape;
        }

        public void ChangeAttackShape(int newShape)
        {
            attackShape = newShape;
        }

        public void Heal(int healAmount)
        {
            GameManager.playerUI.AddEvent(name + " healed " + healAmount + " HP!");
            health += healAmount;
            if (health > maxHealth)
                health = maxHealth;
        }

        public virtual void TakeDamage(int damageAmount, bool displayDamage = true)
        {
            if (dead) return;
            if (displayDamage)
                GameManager.playerUI.AddEvent(name + " took " + damageAmount + " damage!");
            health -= damageAmount;
            if (health <= 0)
            {
                health = 0;
                Die();
            }
        }
    }
}