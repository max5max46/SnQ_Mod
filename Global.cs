using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Global
    {
        // item value constants
        public const int HEAL_SMALL = 2;
        public const int SMALL_BOMB_DAMAGE = 5;

        // movement behaviour constants
        public const int BEHAVIOUR_RANDOM = 0;
        public const int BEHAVIOUR_CHASE = 1;
        public const int BEHAVIOUR_LAVA = 2;

        // attack shape constants
        public const int CROSS_ATTACK = 0;
        public const int SPACE_ATTACK = 1;
        public const int LONG_ATTACK = 2;
        public const int RING_ATTACK = 3;
        public const int X_ATTACK = 4;

        // character constants
        public const char PLAYER_CHAR = '@';
        public const char ROAMER_CHAR = '0';
        public const char CHARGER_CHAR = 'V';
        public const char LAVA_CHAR = '!';

        // map display constants
        public const char MAP_GRASS = '`';
        public const char MAP_WATER = '~';
        public const char MAP_MOUNTAIN = '^';
        public const char MAP_FOREST = '*';
        public const char MAP_SAND = '"';
        public const char MAP_WOOD = '=';
        public const char MAP_WALL = '▓';
    }
}