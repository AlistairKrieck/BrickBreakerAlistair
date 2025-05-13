using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Projectile
    {
        public float x, y, speed, xSpeed, ySpeed, targetX, targetY;
        public int width, height;
        public string image;
        public double angle;
        public Color color;

        public void Move()
        {
            x += xSpeed;
            y += ySpeed;
        }

        public void GetTarget(Paddle p)
        {
            targetX = p.x + (p.width / 2);
            targetY = p.y + (p.height / 2);
        }

        public void GetAngle()
        {
            //Finds the x and y difference between top left corners of paddle and arrow
            double deltaX = targetX - x;
            double deltaY = targetY - y;

            //Finds the distance between top left corners of paddle and arrow
            double distance = Math.Sqrt(Math.Pow(deltaY, 2) + Math.Pow(deltaX, 2));

            //Finds the angle in radians between top left corners of paddle and arrow
            angle = Math.Acos(deltaX / distance);
        }

        public bool PaddleCollision(Paddle p)
        {
            Rectangle projRec = new Rectangle((int)x, (int)y, width, height);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (projRec.IntersectsWith(paddleRec))
            {
                return true;
            }

            return false;
        }


        //public void WallCollision(UserControl UC)
        //{
        //// Collision with left wall
        //if (x <= 0)
        //{
        //    xSpeed *= -1;
        //}

        //// Collision with right wall
        //if (x >= (UC.Width - width))
        //{
        //    xSpeed *= -1;
        //}

        //// Collision with bottom wall
        //if (y >= UC.Height)
        //{
        //    ySpeed *= -1;
        //}
        //}

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
