using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    internal class Bricks
    {
        public static int width = 40;
        public static int height = 40;
        public static int numRows = 5;
        public static int numCols = 10;
        public static int spacing = 5;

        public Rectangle Rect { get; set; }

        public static int x, y;

        public Bricks(int _x, int _y)
        {
            x = _x;
            y = _y;

            Rect = new Rectangle(x, y, width, height);
        }
    }
}
