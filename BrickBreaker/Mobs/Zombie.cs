using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Zombie : Bricks
    {
        public Zombie(int _x, int _y) : base(_x, _y, "zombie", GameScreen.brickImages["zombie"])
        {
            maxHp = hp = 1;
        }

        public ZombieSpit AttackPlayer()
        {
            return new ZombieSpit(x + width / 2, y + height / 2, GameScreen.spitSpeed);
        }
    }
}
