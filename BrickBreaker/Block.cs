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

        public static int width = 40;
        public static int height = 40;
        public static int numRows = 5;
        public static int numCols = 10;
        public static int spacing = 5;
        public Rectangle Rect { get; set; }
        public Brush Color { get; set; }

        int X_;

        public Block(int x, int y, int width, int height)
        {
            Rect = new Rectangle(x, y, width, height);
            X_ = x;

        }
        public int returnX()
        {
            return X_;
        }
    }
}
