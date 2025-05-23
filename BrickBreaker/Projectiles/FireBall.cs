using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class FireBall : Projectile
    {
        // Gets the diameter of the fireball object from GameScreen
        public int diameter = GameScreen.fireBallDiameter;

        public FireBall(int _x, int _y, int _speed)
        {
            x = _x;
            y = _y;
            speed = _speed;

            // Set colour of the fireball to a fiery red
            projBrush = new SolidBrush(Color.Firebrick);

            // Set all constant variables
            InitProjectile();
        }
    }
}
