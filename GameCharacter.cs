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

        protected char character;
        protected ConsoleColor color;

        protected int x;
        protected int y;

        public void GetMap(Map map)
        {
            this.map = map;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = color;
            Console.Write(character);
        }

        public abstract void Update();

        protected void MoveUp()
        {
            if (!map.IsWall(x, y - 1))
                y -= 1;
        }
        protected void MoveDown()
        {
            if (!map.IsWall(x, y + 1))
                y += 1;
        }
        protected void MoveLeft()
        {
            if (!map.IsWall(x - 1, y))
                x -= 1;
        }
        protected void MoveRight()
        {
            if (!map.IsWall(x + 1, y))
                x += 1;
        }
    }
}