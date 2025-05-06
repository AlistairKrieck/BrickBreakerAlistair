using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class LevelDesign : UserControl
    {
        int x, y, width, height;
        string textureValue;
        int button = 1;
        List<BlockSave> blocks = new List<BlockSave>();

        bool canContinue = true;
        public LevelDesign()
        {
            InitializeComponent();
            Saving();
        }

        private void Saving() 
        {
            Text.Text = "e";
            button = 1;
            string test = $"block" + button;
            test = $"{test}.Location.X";


            while (canContinue == true)
            {
                try
                {
                    x = block1.Location.X;
                    y = block1.Location.Y;
                    textureValue = block1.Text;
                    width = block1.Width;
                    height = block1.Height;

                    BlockSave newBlockSave = new BlockSave(x, y, textureValue, width, height);
                    blocks.Add(newBlockSave);
                }

                catch { 
                    canContinue = false;
                }
            }

            this.Refresh();
        }
    }
}
