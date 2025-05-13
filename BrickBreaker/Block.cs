using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public class Block
    {
        public int x, y;
        public static int width = 40;
        public static int height = 40;
        public static int numRows = 5;
        public static int numCols = 10;
        public static int spacing = 5;
        public Rectangle Rect { get; set; }
        public Brush Color { get; set; }

        public Block(int _x, int _y)
        {
            x = _x;
            y = _y;

            Rect = new Rectangle(x, y, width, height);
        }
    }
}
