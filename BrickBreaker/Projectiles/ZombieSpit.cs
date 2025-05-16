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
        public int diameter = GameScreen.spitDiameter;

        public ZombieSpit(int _x, int _y, int _speed)
        {
            x = _x;
            y = _y;
            speed = _speed;

            image = "slimeball";
            projBrush = new SolidBrush(Color.GreenYellow);

            GetTarget(GameScreen.paddle);
            GetAngle();

            xSpeed = (float)(Math.Cos(angle) * speed);
            ySpeed = -(float)(Math.Sin(angle) * speed);
        }
    }
}
