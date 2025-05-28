using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Bricks
    {
        // Static properties for all Bricks
        public static int width = 120;
        public static int height = 40;

        // Types that are "ores"
        public static string[] ores = new string[] { "coal", "iron", "copper", "deepslateCoal", "deepslateIron", "deepslateLapis", "deepslateRedstone", "deepslateDiamond", "netherGold", "netherite", "quartz" };

        // Types that are "mobs"
        public static string[] mobs = new string[] { "zombie", "skeleton", "blaze" };

        // Instance properties
        public int x, y;
        public int hp;
        public int maxHp;
        public Rectangle rect;
        public string brickType;
        public Image image;

        public Bricks(int _x, int _y, string _type, Image _image)
        {
            x = _x;
            y = _y;

            rect = new Rectangle(_x, _y, width, height);
            brickType = _type;
            image = _image;

            // Set health points based on the type of brick
            switch (_type)
            {
                case "dirt":
                case "grass":
                case "netherack":
                    maxHp = hp = 1;
                    break;

                case "stone":
                case "andesite":
                case "granite":
                case "magma":
                    maxHp = hp = 2;
                    break;

                case "coal":
                case "iron":
                case "copper":
                case "netherGold":
                case "quartz":
                    maxHp = hp = 3;
                    break;

                case "deepslate":
                case "deepslateTile":
                    maxHp = hp = 3;
                    break;

                case "deepslateCoal":
                case "deepslateIron":
                case "deepslateLapis":
                case "deepslateRedstone":
                case "deepslateDiamond":
                    maxHp = hp = 4;
                    break;

                case "netherite":
                case "obsidian":
                case "bedrock":
                    maxHp = hp = 5;
                    break;

                default:
                    maxHp = hp = 1;
                    break;
            }
        }

        // Reduce health by 1
        public void TakeDamage()
        {
            hp--;
        }
    }
}
