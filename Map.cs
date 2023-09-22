using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Text_Based_RPG
{
    internal class Map
    {
        // LEGEND
        // ` - grass
        // ~ - water
        // ^ - mountain
        // * - forest
        // " - sand
        // = - wood
        // ▓ - Wall

        public char[,] map;

        public void Draw(Render render)
        {
            for (int i = 0; i < map.GetLength(0); i++)
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    switch (map[i, j])
                    {
                        case Global.MAP_GRASS:
                            render.ChangeSpace(map[i, j], ConsoleColor.Green, ConsoleColor.Black, j, i);
                            break;
                        case Global.MAP_SAND:
                            render.ChangeSpace(map[i, j], ConsoleColor.Yellow, ConsoleColor.Black, j, i);
                            break;
                        case Global.MAP_FOREST:
                            render.ChangeSpace(map[i, j], ConsoleColor.DarkGreen, ConsoleColor.Black, j, i);
                            break;
                        case Global.MAP_MOUNTAIN:
                            render.ChangeSpace(map[i, j], ConsoleColor.DarkGray, ConsoleColor.Black, j, i);
                            break;
                        case Global.MAP_WATER:
                            render.ChangeSpace(map[i, j], ConsoleColor.Blue, ConsoleColor.Black, j, i);
                            break;
                        case Global.MAP_WOOD:
                            render.ChangeSpace(map[i, j], ConsoleColor.DarkYellow, ConsoleColor.Black, j, i);
                            break;
                        case Global.MAP_WALL:
                            render.ChangeSpace(map[i, j], ConsoleColor.Black, ConsoleColor.DarkGray, j, i);
                            break;
                        case Global.MAP_HOLE:
                            render.ChangeSpace(map[i, j], ConsoleColor.Black, ConsoleColor.Black, j, i);
                            break;
                        case Global.MAP_HOLE_FALSE:
                            render.ChangeSpace(map[i, j], ConsoleColor.Black, ConsoleColor.Black, j, i);
                            break;
                        case Global.MAP_SHOP:
                            render.ChangeSpace(map[i, j], ConsoleColor.DarkYellow, ConsoleColor.Black, j, i);
                            break;
                        case Global.MAP_SHOP_R:
                            render.ChangeSpace(map[i, j], ConsoleColor.DarkYellow, ConsoleColor.Black, j, i);
                            break;
                    }
                }
        }

        public bool IsWall(int x, int y, bool waterWalking)
        {
            try
            {
                switch (map[y, x])
                {
                    case Global.MAP_GRASS:
                    case Global.MAP_SAND:
                    case Global.MAP_FOREST:
                    case Global.MAP_WOOD:
                    case Global.MAP_SHOP:
                    case Global.MAP_SHOP_R:
                    case Global.MAP_HOLE_FALSE:
                        return false;
                    case Global.MAP_WATER:
                        if (waterWalking) return false;
                        return true;
                    case Global.MAP_MOUNTAIN:
                    case Global.MAP_WALL:
                    case Global.MAP_HOLE:
                    default:
                        return true;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }

        public void FillSpace(int x, int y, Render render)
        {
            /*switch (map[y, x])
            {
                case '`':
                    render.ChangeSpace(map[y, x], ConsoleColor.Green, ConsoleColor.Black, x, y);
                    break;
                case '"':
                    render.ChangeSpace(map[y, x], ConsoleColor.Yellow, ConsoleColor.Black, x, y);
                    break;
                case '*':
                    render.ChangeSpace(map[y, x], ConsoleColor.DarkGreen, ConsoleColor.Black, x, y);
                    break;
                case '^':
                    render.ChangeSpace(map[y, x], ConsoleColor.DarkGray, ConsoleColor.Black, x, y);
                    break;
                case '~':
                    render.ChangeSpace(map[y, x], ConsoleColor.Blue, ConsoleColor.Black, x, y);
                    break;
            }*/
        }

        public Map()
        {
            string[] mapString = File.ReadAllLines("Map.txt");
            map = new char[mapString.GetLength(0),mapString[0].Length];

            for (int i = 0; i < mapString.GetLength(0); i++)
                for (int j = 0; j < mapString[0].Length; j++)
                    map[i,j] = mapString[i][j];
        }

        public int Width()
        {
            return map.GetLength(1);
        }
        public int Height()
        {
            return map.GetLength(0);
        }

        public char GetChar(int x, int y)
        {
            return map[y,x];
        }
    }
}