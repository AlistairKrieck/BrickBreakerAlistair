using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public int x, y, xSpeed, ySpeed, size;
        public Color colour;

        public static Random rand = new Random();

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed, int _ballSize)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            size = _ballSize;
        }

        public void Move()
        {
            x += xSpeed;
            y += ySpeed;
        }

        public bool Collision(Rectangle rect)
        {
            Rectangle ballRect = new Rectangle(x, y, size, size);
            return ballRect.IntersectsWith(rect);
        }

        public void PaddleCollision(Paddle p)
        {
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (ballRec.IntersectsWith(paddleRec))
            {
                ySpeedLimit();

                if (ballRec.X < paddleRec.X + p.width / 2 && xSpeed > 0)
                {
                    xSpeed *= -1;
                }
                if (ballRec.X > paddleRec.X + p.width / 2 && xSpeed < 0)
                {
                    xSpeed *= -1;
                }
            }
        }

        public void ySpeedLimit()
        {
            if (ySpeed >= 0 && ySpeed >= 8)
            {
                ySpeed++;
            }
            if (ySpeed < 0 && ySpeed >= -8)
            {
                ySpeed--;
            }

            ySpeed *= -1;
        }

        public void xSpeedLimit()
        {
            if (xSpeed >= 0 && xSpeed >= 8)
            {
                xSpeed++;
            }
            if (xSpeed < 0 && xSpeed >= -8)
            {
                xSpeed--;
            }
        }

        public void OverallSpeedLimit()
        {
            if (xSpeed == 10 || ySpeed == 10 || ySpeed == -10)
            {
                ySpeed = 6;
                xSpeed = 6;
            }
            else if (xSpeed == -10)
            {
                xSpeed = -6;
            }
        }

        public void WallCollision(UserControl UC)
        {
            // Collision with left wall
            if (x <= 0)
            {
                xSpeedLimit();
            }
            // Collision with right wall
            if (x >= (UC.Width - size))
            {
                xSpeedLimit();
            }
            // Collision with bottom wall
            if (y >= UC.Height)
            {
                ySpeed *= -1;

                if (xSpeed == 0)
                {
                    xSpeed = 3;
                }
            }
        }

        public bool TopCollision(UserControl UC)
        {
            Boolean didCollide = false;

            if (y <= 0)
            {
                didCollide = true;
            }

            return didCollide;
        }

    }
}
