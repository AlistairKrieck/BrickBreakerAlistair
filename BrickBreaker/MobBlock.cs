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
        public int speed;

        public MobBlock(int _x, int _y, int _hp, Color _colour, string _mobType) : base(_x, _y, _hp, _colour)
        {
            mobType = _mobType;
        }

        public void Move(string direction)
        {
            if (direction == "left")
            {
                x -= speed;
            }
            if (direction == "right")
            {
                x += speed;
            }
        }

        public void AttackPlayer()
        {


        }
    }
}
