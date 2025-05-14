using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Zombie : MobBlock
    {
        public Zombie(int _x, int _y) : base(_x, _y)
        {
            mobColor = System.Drawing.Color.Green;
            mobType = "zombie";
        }

        public ZombieSpit AttackPlayer()
        {
            return new ZombieSpit(x + width / 2, y + height / 2, GameScreen.spitSpeed);
        }
    }
}
