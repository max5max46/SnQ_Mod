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
        };

        public String[] EventLog = new string[8];

        public PlayerUI(Player player)
        {
            this.player = player;

            for (int i = 0; i < EventLog.GetLength(0); i++)
            {
                EventLog[i] = "";
            }
        }

        public void Draw(Map map)
        {
            Console.SetCursorPosition(0, map.map.GetLength(0));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(UIText[0]);
            Console.WriteLine(UIText[1] + player.GetHealth() + "  ");
            Console.WriteLine(UIText[0]);

            for (int i = 0; i < EventLog.GetLength(0); i++)
            {
                Console.WriteLine(EventLog[i] + "                     ");
            }
        }

        public void AddEvent(string Event)
        {
            for (int i = 0; i < EventLog.GetLength(0); i++)
            {
                if (EventLog[i] == "")
                {
                    EventLog[i] = Event;
                    return;
                }
            }
            for (int i = 0; i < EventLog.GetLength(0) - 1; i++)
            {
                EventLog[i] = EventLog[i + 1];
            }
            EventLog[EventLog.GetLength(0) - 1] = Event;
        }
    }
}