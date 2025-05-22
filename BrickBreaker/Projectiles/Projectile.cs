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
        public float width, height;
        public double angle;
        public SolidBrush projBrush;

        // Update the projectiles position based on its x and y speeds
        public void Move()
        {
            x += xSpeed;
            y += ySpeed;
        }

        // Sets the targetX and targetY to the center of the paddle
        public void GetTarget(Paddle p)
        {
            targetX = p.x + (p.width / 2);
            targetY = p.y + (p.height / 2);
        }

        // Calculates the angle bewteen the projectile and its target
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

        // Set the targetX, targetY, angle, xSpeed, and ySpeed variables
        public void InitProjectile()
        {
            // Sets targetX and targetY variables to the center of the paddle
            GetTarget(GameScreen.paddle);

            // Gets the angle between the projectile and target point
            GetAngle();

            // Set x and y speeds such that the projectile travels its speed in pixels on the diagonal between it and the target
            xSpeed = (float)(Math.Cos(angle) * speed);
            ySpeed = -(float)(Math.Sin(angle) * speed);
        }

        // Returns true if the projectile collides with the paddle
        public bool PaddleCollision(Paddle p)
        {
            // Create rectangles to check intersection between projectile and paddle
            Rectangle projRec = new Rectangle((int)x, (int)y, (int)width, (int)height);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (projRec.IntersectsWith(paddleRec))
            {
                return true;
            }

            return false;
        }

        // Returns true if the projectile has hit the top wall
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
