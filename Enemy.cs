using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Enemy : GameCharacter
    {
        public override void Update()
        {
            MoveAI();
        }

        public void MoveAI()
        {

        }
    }
}