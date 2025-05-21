using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    internal class BlockSave
    {
        int x, y, width, height;
        string textureValue;
        public BlockSave(int _x, int _y, string _textureValue, int _width, int _height)
        {
            x = _x;
            y = _y;
            textureValue = _textureValue;
            width = _width;
            height = _height;
        }
    }
}
