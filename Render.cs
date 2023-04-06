using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Render
    {
        RenderSpace[,] wholeMap, camBufferPrev, camBufferNext;

        Map map;
        Camera camera;

        struct RenderSpace
        {
            public char Char;
            public ConsoleColor BG;
            public ConsoleColor FG;
        }

        public Render(Map map)
        {
            this.map = map;

            wholeMap = new RenderSpace[map.Height(), map.Width()];
            camBufferPrev = new RenderSpace[Global.CAMERA_RADIUS * 2, Global.CAMERA_RADIUS * 2];
            camBufferNext = new RenderSpace[Global.CAMERA_RADIUS * 2, Global.CAMERA_RADIUS * 2];
        }

        public void ChangeSpace(char NewChar, ConsoleColor NewBGColour, ConsoleColor NewFGColour, int x, int y)
        {
            wholeMap[y, x] = new RenderSpace();
            wholeMap[y, x].Char = NewChar;
            wholeMap[y, x].BG = NewBGColour;
            wholeMap[y, x].FG = NewFGColour;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            for (int y = 0; y < camBufferNext.GetLength(0); y++)
            {
                for (int x = 0; x < camBufferNext.GetLength(1); x++)
                {
                    camBufferNext[y, x] = wholeMap[y + camera.GetPos()[1] - Global.CAMERA_RADIUS + 1, x + camera.GetPos()[0] - Global.CAMERA_RADIUS + 1];
                    Console.SetCursorPosition(x * 2, y);
                    Console.BackgroundColor = camBufferNext[y, x].BG;
                    Console.ForegroundColor = camBufferNext[y, x].FG;
                    Console.Write(camBufferNext[y, x].Char);
                    Console.Write(camBufferNext[y, x].Char);
                }
            }
            camBufferPrev = camBufferNext;
        }

        public void GetCamera(Camera camera)
        {
            this.camera = camera;
        }
    }
}