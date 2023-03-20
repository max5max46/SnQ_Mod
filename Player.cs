using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Player : GameCharacter
    {
        EnemyManager enemyManager;

        public Player(int x, int y, int health, Map map, AttackMap attackMap, Render render) : base(x, y, health, map, attackMap, render)
        {
            character = '@';
            color = ConsoleColor.White;
            attackColor = ConsoleColor.Magenta;
            baseColor = color;
            attackShape = Global.CROSS_ATTACK;
            kamikaze = false;
            strength = 1;
            name = "player";
            waterWalking = false;
        }

        public override void Update()
        {
            base.Update();
            if (dead)
                return;

            TakeInput();
        }

        protected void TakeInput()
        {
            switch (GameManager.pressedKey)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    yDelta--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    yDelta++;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    xDelta--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    xDelta++;
                    break;
                case ConsoleKey.Spacebar:
                    Attack(attackShape);
                    break;
            }
            Move();
        }

        protected override void Attack(int attackShape)
        {
            base.Attack(attackShape);

            enemyManager.DamageEnemies();
        }

        public void GetEnemyManager(EnemyManager enemyManager)
        {
            this.enemyManager = enemyManager;
        }

        public void getBoat()
        {
            if (!waterWalking) waterWalking = true;
        }
    }
}