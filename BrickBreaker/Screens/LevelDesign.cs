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
        string type;
        List<Block> blocks = new List<Block>();
        bool canContinue = true;

        string levelNum;

        public LevelDesign()
        {
            InitializeComponent();
            //Saving();
            //SaveLevel();

            LoadLevel();
        }

        //private void Saving()
        //{
        //    Text.Text = "e";
        //    button = 1;
        //    string test = $"block" + button;
        //    test = $"{test}.Location.X";


        //    while (canContinue == true)
        //    {
        //        try
        //        {
        //            x = block1.Location.X;
        //            y = block1.Location.Y;
        //            textureValue = block1.Text;
        //            width = block1.Width;
        //            height = block1.Height;

        //            BlockSave newBlockSave = new BlockSave(x, y, textureValue, width, height);
        //            blocks.Add(newBlockSave);
        //        }

        //        catch
        //        {
        //            canContinue = false;
        //        }
        //    }

        //    this.Refresh();
        //}

        private void SaveLevel()
        {
            levelNum = Text.Text;

            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    x = c.Location.X;
                    y = c.Location.Y;
                    type = c.Text;

                    Block newBlock = new Block(x, y, type);
                    blocks.Add(newBlock);
                }
            }

            Level level = new Level();
            level.SaveLevel(levelNum, blocks);
        }

        public void LoadLevel()
        {
            levelNum = Text.Text;
            Level level = new Level();
            List<Block> blah = level.LoadLevel(levelNum);
        }
    }
}
