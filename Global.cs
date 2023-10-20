using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Global
    {
        // map display constants
        public const char MAP_GRASS = '`';
        public const char MAP_WATER = '~';
        public const char MAP_MOUNTAIN = '^';
        public const char MAP_FOREST = '*';
        public const char MAP_SAND = '"';
        public const char MAP_WOOD = '=';
        public const char MAP_WALL = '▓';
        public const char MAP_HOLE = 'n';
        public const char MAP_HOLE_FALSE = 'f';
        public const char MAP_SHOP = 'x';
        public const char MAP_SHOP_R = 'r';

        // attack shape constants
        public const int CROSS_ATTACK = 0;
        public const int SPACE_ATTACK = 1;
        public const int LONG_ATTACK = 2;
        public const int RING_ATTACK = 3;
        public const int X_ATTACK = 4;

        // player constants (char)
        public const char PLAYER_CHAR = '@';

        // item character constants
        public const char HEALTH_CHAR = '♥';
        public const char HEALTH_CHAR2 = '+';
        public const char COINBAG_CHAR = 'C';
        public const char SPEAR_CHAR = '↑';
        public const char BOMB_CHAR = 'B';
        public const char BOAT_CHAR = 'U';
        public const char HULA_CHAR = 'O';
        public const char GEM_CHAR = '♦';

        // item value constants
        public int HEAL_SMALL { get; set; }
        public int HEAL_LARGE { get; set; }
        public int SMALL_BOMB_DAMAGE { get; set; }

        // player constants
        public int PLAYER_HP { get; set; }
        public int PLAYER_START_COINS { get; set; }
        public int PLAYER_STRENGTH { get; set; }

        // player starting position
        public int START_X { get; set; }
        public int START_Y { get; set; }

        // coin constants
        public int COINBAG_RANGE { get; set; }
        public int COINBAG_MIN { get; set; }
        public int HEALTH_COST { get; set; }
        public int HEALTH_COST2 { get; set; }
        public int SPEAR_COST { get; set; }
        public int BOMB_COST { get; set; }
        public int BOAT_COST { get; set; }
        public int HULA_COST { get; set; }
        public int GEM_COST { get; set; }
        public int COINBAG_COST { get; set; }

        // quest char contants
        public const char UNACCEPTED_QUEST = '?';
        public const char ACCEPTED_QUEST = '?';
        public const char NOT_TURNED_IN_QUEST = '!';
        public const char RANDOM_QUEST_CHAR = 'R';
        public const char GIVE_HEALTH_QUEST_CHAR = 'H';
        public const char GIVE_SPEAR_QUEST_CHAR = 'S';
        public const char GIVE_HULA_QUEST_CHAR = 'O';

        // quest reward contants
        public int GIVE_HEALTH_QUEST_REWARD_RANGE { get; set; }
        public int GIVE_HEALTH_QUEST_REWARD_MIN { get; set; }
        public int GIVE_SPEAR_QUEST_REWARD_RANGE { get; set; }
        public int GIVE_SPEAR_QUEST_REWARD_MIN { get; set; }
        public int GIVE_HULA_QUEST_REWARD_RANGE { get; set; }
        public int GIVE_HULA_QUEST_REWARD_MIN { get; set; }


        // camera radius
        public int CAMERA_RADIUS { get; set; }

        // event log length
        public int EVENT_LOG_LENGTH { get; set; }

        // random class constant
        public static Random random = new Random();

        public static int ConvertAttackType(string attackName)
        {
            switch (attackName)
            {
                case "cross_attack": return 0;
                case "space_attack": return 1;
                case "long_attack": return 2;
                case "ring_attack": return 3;
                case "x_attack": return 4;
                default: return 0;
            }
        }

        public static Global GetFromJSON()
        {
            string dataPath = "settings.json";
            string jsonData = File.ReadAllText(dataPath);
            var settingsData = JsonSerializer.Deserialize<Global>(jsonData);
            return settingsData;
        }
    }
}