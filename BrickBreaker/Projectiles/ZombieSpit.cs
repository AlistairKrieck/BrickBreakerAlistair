using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class ZombieSpit : Projectile
    {
        // Gets the diameter of the spit object from GameScreen
        public int diameter = GameScreen.spitDiameter;

        public ZombieSpit(int _x, int _y, int _speed)
        {
            x = _x;
            y = _y;
            speed = _speed;

            // Set colour of the spit to a gross yellow-green
            projBrush = new SolidBrush(Color.GreenYellow);

            // Set all constant variables
            InitProjectile();
        }
    }
}
