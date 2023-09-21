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
            "----------------------",
            "HP:        Coins: ",
            "----------------------",
        };

        public String[] EventLog = new string[Global.EVENT_LOG_LENGTH];

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
            Console.SetCursorPosition(0, Global.CAMERA_RADIUS * 2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(UIText[0]);
            Console.WriteLine(UIText[1]);
            Console.SetCursorPosition(4, (Global.CAMERA_RADIUS * 2) + 1); Console.Write(player.GetHealth() + "  ");
            Console.SetCursorPosition(18, (Global.CAMERA_RADIUS * 2) + 1); Console.Write(player.GetCoins() + "  ");
            Console.WriteLine("\n" + UIText[0]);

            for (int i = 0; i < EventLog.GetLength(0); i++)
            {
                string overwrite = "";
                for (int j = 0; j < Console.WindowWidth - EventLog[i].Length - 1; j++)
                    overwrite += " ";

                Console.WriteLine(EventLog[i] + overwrite);
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