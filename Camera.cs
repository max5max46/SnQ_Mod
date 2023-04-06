using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Camera
    {
        private int x, y;
        private Player player;
        private Map map;

        public Camera(Player player, Map map)
        {
            this.player = player;
            this.map = map;

            x = 0;
            y = 0;
        }

        public void Update()
        {
            x = player.GetPos()[0];
            y = player.GetPos()[1];
            if (x <= Global.CAMERA_RADIUS - 2) x = Global.CAMERA_RADIUS - 1;
            if (y <= Global.CAMERA_RADIUS - 2) y = Global.CAMERA_RADIUS - 1;
            if (x > map.Width() - Global.CAMERA_RADIUS - 1) x = map.Width() - Global.CAMERA_RADIUS - 1;
            if (y >= map.Height() - Global.CAMERA_RADIUS) y = map.Height() - Global.CAMERA_RADIUS - 1;
        }

        public int[] GetPos()
        {
            return new int[] { x, y };
        }
    }
}
