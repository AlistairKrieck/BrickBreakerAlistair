using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Creeper : MobBlock
    {
        public Creeper(int _x, int _y) : base(_x, _y)
        {
            mobBrush = new SolidBrush(System.Drawing.Color.DarkOliveGreen);
            mobType = "creeper";
        }

        private List<Block> Explode(List<Block> remainingBlocks)
        {
            //radius of explosion
            int range = 20;

            List<Block> destroyedBlocks = new List<Block>();

            foreach (var b in remainingBlocks)
            {
                if (b.x < x + range && b.x < x - range && b.y < y + range && b.y < y - range)
                {
                    destroyedBlocks.Add(b);
                }
            }

            return destroyedBlocks;
        }
    }
}
