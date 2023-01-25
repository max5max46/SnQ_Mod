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

        protected int x;
        protected int y;

        public GameCharacter(Map map)
        {
            GetMap(map);
        }

        public void GetMap(Map map)
        {
            this.map = map;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(character);
        }

        public abstract void Update();

        protected void MoveUp()
        {
            if (true) { } ;
        }
    }
}