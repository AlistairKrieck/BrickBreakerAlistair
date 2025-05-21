using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public class MobBlock : Bricks
    {
        public string mobType;

        public static string[] mobTypes = { "skeleton", "zombie" };

        public MobBlock(int _x, int _y) : base(_x, _y)
        {

        }
    }
}
