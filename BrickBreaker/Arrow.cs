using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Arrow
    {
        public int x, y, speed, xSpeed, ySpeed, height, width, targetX, targetY;
        public string image;

        public Arrow(int _x, int _y, int _speed, int _width, int _height)
        {
            x = _x;
            y = _y;
            speed = _speed;
            width = _width;
            height = _height;

            double deltaX = targetX - x;
            double deltaY = targetY - y;

            double slope = deltaY / deltaX;
            double angle = Math.Acos(deltaX / slope);

            xSpeed = (int)Math.Cos(angle) * speed;
            ySpeed = (int)Math.Sin(angle) * speed;
        }

        public void GetTarget()
        {

        }

        public void Move()
        {
            x += xSpeed;
            y += ySpeed;
        }

        public bool PaddleCollision(Paddle p)
        {
            Rectangle arrowRec = new Rectangle(x, y, width, height);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (arrowRec.IntersectsWith(paddleRec))
            {
                GameScreen.lives--;
                return true;
            }

            return false;
        }

        public void WallCollision(UserControl UC)
        {
            // Collision with left wall
            if (x <= 0)
            {
                xSpeed *= -1;
            }

            // Collision with right wall
            if (x >= (UC.Width - width))
            {
                xSpeed *= -1;
            }

            // Collision with bottom wall
            if (y >= UC.Height)
            {
                ySpeed *= -1;
            }
        }

        public bool TopCollision()
        {
            if (y <= 0)
            {
                return true;
            }

            return false;
        }
    }
}
