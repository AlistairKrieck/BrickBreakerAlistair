using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Blaze : Bricks
    {
        public Blaze(int _x, int _y) : base(_x, _y, "blaze", GameScreen.brickImages["blaze"])
        {
            maxHp = hp = 1;
        }

        public FireBall AttackPlayer()
        {
            return new FireBall(x + width / 2, y + height / 2, GameScreen.spitSpeed);
        }
    }
}
