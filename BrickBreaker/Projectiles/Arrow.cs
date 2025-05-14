using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Arrow : Projectile
    {
        public PointF[] points = new PointF[4];

        public Arrow(int _x, int _y, int _speed)
        {
            x = _x;
            y = _y;
            speed = _speed;

            height = GameScreen.arrowHeight;
            width = GameScreen.arrowWidth;

            image = "arrow";
            color = Color.Brown;

            GetTarget(GameScreen.paddle);
            GetAngle();

            GetArrowBody();

            xSpeed = (float)(Math.Cos(angle) * speed);
            ySpeed = -(float)(Math.Sin(angle) * speed);
        }

        public void GetArrowBody()
        {
            float alpha = (float)(Math.PI / 2 - angle);

            float angleCos = (float)Math.Cos(angle);
            float angleSin = (float)Math.Sin(angle);

            float alphaCos = (float)Math.Cos(alpha);
            float alphaSin = (float)Math.Sin(alpha);

            float xDif1 = width * alphaCos;
            float yDif1 = width * alphaSin;

            float xDif2 = height * angleCos;
            float yDif2 = height * angleSin;

            points[0] = new PointF(x, y);
            points[1] = new PointF(x + xDif1, y + yDif1);
            points[2] = new PointF(x + xDif1 - xDif2, y + yDif1 + yDif2);
            points[3] = new PointF(x - xDif2, y + yDif2);
        }

        public void Move()
        {
            x += xSpeed;
            y += ySpeed;

            GetArrowBody();
        }
    }
}
