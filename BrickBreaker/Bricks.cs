using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    internal class Bricks
    {
        // Static properties for all Bricks
        public static int width = 80;
        public static int height = 40;
        public static int numRows = 5;
        public static int numCols = 10;
        public static int spacing = 5;

        // Instance properties
        public int hp { get; set; }
        public Rectangle Rect { get; set; }
        public GameScreen.BrickType BrickType { get; set; }
        public Image Image { get; set; }

        public Bricks(int _x, int _y, GameScreen.BrickType _type, Image _image)
        {
            Rect = new Rectangle(_x, _y, width, height);
            BrickType = _type;
            Image = _image;

            // Set health points based on the type of brick
            switch (_type)
            {
                case GameScreen.BrickType.Grass:
                    hp = 1;
                    break;
                case GameScreen.BrickType.Dirt:
                    hp = 2;
                    break;
                case GameScreen.BrickType.Stone:
                    hp = 3;
                    break;

                case GameScreen.BrickType.Deepslate:
                    hp = 2;
                    break;
                case GameScreen.BrickType.Bedrock:
                    hp = 3;
                    break;

                default:
                    hp = 1;
                    break;
            }
        }

        // Reduce health and return if destroyed
        public bool TakeDamage()
        {
            hp--;
            return hp <= 0;
        }
    }
}
