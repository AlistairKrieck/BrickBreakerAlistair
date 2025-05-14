using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public class MobBlock : Block
    {
        public string mobType;
        public int xSpeed = 5;
        public int ySpeed = 5;
        public Color mobColor;

        public static string[] mobTypes = { "skeleton", "zombie", "creeper" };

        public MobBlock(int _x, int _y) : base(_x, _y)
        {

        }

        public void Move(string direction)
        {
            if (direction == "left")
            {
                x -= xSpeed;
            }
            if (direction == "right")
            {
                x += xSpeed;
            }

            if (direction == "up")
            {
                y -= ySpeed;
            }
            if (direction == "down")
            {
                y += ySpeed;
            }

        }
    }
}
