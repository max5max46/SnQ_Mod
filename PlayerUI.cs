using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class PlayerUI
    {
        Player player;

        public String[] UIText =
        {
            "----------",
            "HP: ",
            "----------",
            "LAST ENEMY ENCOUNTERED: "
        };

        public PlayerUI(Player player)
        {
            this.player = player;
        }

        public void Draw(Map map)
        {
            Console.SetCursorPosition(0, map.map.GetLength(0));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(UIText[0]);
            Console.WriteLine(UIText[1] + player.GetHealth() + "  ");
        }
    }
}