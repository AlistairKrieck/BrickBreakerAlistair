using System;
using System.Drawing;
using System.Media;
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
                SoundPlayer player = new SoundPlayer(Properties.Resources.impact2);
                player.Play();

                ySpeedLimit();

                if (ballRec.Y < paddleRec.Y)
                {
                    xSpeedLimit();
                    y = y + size;
                }

                if (ballRec.X < paddleRec.X + p.width / 2 && xSpeed > 0 || ballRec.X > paddleRec.X + p.width / 2 && xSpeed < 0)
                {
                    xSpeed *= -1;
                }
            }
        }

        public void ySpeedLimit()
        {
            if (ySpeed >= 0 && ySpeed >= 7)
            {
                ySpeed++;
            }
            if (ySpeed < 0 && ySpeed >= -7)
            {
                ySpeed--;
            }

            ySpeed *= -1;
        }

        public void xSpeedLimit()
        {
            if (xSpeed >= 0 && xSpeed >= 7)
            {
                xSpeed++;
            }
            if (xSpeed < 0 && xSpeed >= -7)
            {
                xSpeed--;
            }

            xSpeed *= -1;
        }

        public void WallCollision(UserControl UC)
        {
            // Bool to store if any collisions occured to play sound
            bool collided = false;

            // Collision with left wall
            if (x <= 0)
            {
                xSpeedLimit();
                y = y + 5;

                collided = true;
            }
            // Collision with right wall
            if (x >= (UC.Width - size))
            {
                xSpeedLimit();
                y = y - 5;

                collided = true;
            }
            // Collision with bottom wall
            if (y >= UC.Height - size)
            {
                int direction = rand.Next(1, 3);

                ySpeed *= -1;

                if (xSpeed == 0)
                {
                    if (direction == 1)
                    {
                        xSpeed = 2;
                    }
                    else
                    {
                        xSpeed = -2;
                    }
                }

                y = y - 5;

                collided = true;
            }

            // Play sound on collision
            if (collided == true)
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.impact2);
                player.Play();
            }
        }

        public bool TopCollision(UserControl UC)
        {
            Boolean didCollide = false;

            if (y + size <= 0)
            {
                didCollide = true;
            }

            return didCollide;
        }

    }
}
