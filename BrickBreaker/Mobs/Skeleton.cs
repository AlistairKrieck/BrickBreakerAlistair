using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Skeleton : Bricks
    {
        public Skeleton(int _x, int _y) : base(_x, _y, "skeleton", GameScreen.brickImages["skeleton"])
        {
            maxHp = hp = 1;
        }

        public Arrow AttackPlayer()
        {
            return new Arrow(x + width / 2, y + height / 2, GameScreen.arrowSpeed);
        }
    }
}
