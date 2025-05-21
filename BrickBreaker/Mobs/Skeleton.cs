using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Skeleton : MobBlock
    {
        public Skeleton(int _x, int _y) : base(_x, _y)
        {
            mobBrush = new SolidBrush(System.Drawing.Color.White);
            mobType = "skeleton";
        }

        public Arrow AttackPlayer()
        {
            return new Arrow(x + width / 2, y + height / 2, GameScreen.arrowSpeed);
        }
    }
}
