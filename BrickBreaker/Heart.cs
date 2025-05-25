using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Heart
    {
        int x, y, size;
        Image image;

        // Stores what health point it represents
        // I.e. if the player has five health left, this represents the fourth heart in the display of five
        int heartNumber;

        public Heart(int _x, int _y, int _heartNumber, Image _image)
        {
            x = _x;
            y = _y;
            heartNumber = _heartNumber;
            image = _image;
        }
    }
}
