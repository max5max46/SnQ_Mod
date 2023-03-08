using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Render
    {
        char[,] CharBufferPrev, CharBufferNext;

        ConsoleColor[,] BGColourPrev, BGColourNext;

        ConsoleColor[,] FGColourPrev, FGColourNext;

        Map map;

        public Render(Map map)
        {
            this.map = map;

            CharBufferPrev = new char[map.map.GetLength(0), map.map.GetLength(1)];
            CharBufferNext = new char[map.map.GetLength(0), map.map.GetLength(1)];

            BGColourPrev = new ConsoleColor[map.map.GetLength(0), map.map.GetLength(1)];
            BGColourNext = new ConsoleColor[map.map.GetLength(0), map.map.GetLength(1)];

            FGColourPrev = new ConsoleColor[map.map.GetLength(0), map.map.GetLength(1)];
            FGColourNext = new ConsoleColor[map.map.GetLength(0), map.map.GetLength(1)];
        }

        public void SetWindowSize(PlayerUI playerUI)
        {
            Console.WindowHeight = map.map.GetLength(0) + playerUI.UIText.GetLength(0) + playerUI.EventLog.GetLength(0) + 1;
            Console.WindowWidth = map.map.GetLength(1) * 2;
        }

        public void ChangeSpace(char NewChar, ConsoleColor NewBGColour, ConsoleColor NewFGColour, int x, int y)
        {
            CharBufferNext[y, x] = NewChar;
            BGColourNext[y, x] = NewBGColour;
            FGColourNext[y, x] = NewFGColour;
        }

        public void Draw()
        {
            for (int i = 0; i < CharBufferPrev.GetLength(0); i++)
            { 
                for (int j = 0; j < CharBufferPrev.GetLength(1); j++)
                {
                    if (CharBufferPrev[i, j] != CharBufferNext[i, j] || BGColourPrev[i, j] != BGColourPrev[i, j] || FGColourPrev[i, j] != FGColourNext[i, j])
                    {
                        Console.SetCursorPosition(j * 2, i);
                        Console.BackgroundColor = BGColourNext[i, j];
                        Console.ForegroundColor = FGColourNext[i, j];
                        Console.Write(CharBufferNext[i, j]);
                        Console.Write(CharBufferNext[i, j]);

                        CharBufferPrev[i, j] = CharBufferNext[i, j];
                        BGColourPrev[i, j] = BGColourNext[i, j];
                        FGColourPrev[i, j] = FGColourNext[i, j];
                    }
                }
            }
        }
    }
}