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
        List<Bricks> bricks = new List<Bricks>();
        bool canContinue = true;

        private void saveLabel_Click(object sender, EventArgs e)
        {
            SaveLevel();
        }

        string levelNum;

        public LevelDesign()
        {
            InitializeComponent();
            //Saving();

            SaveLevel();
        }

        private void SaveLevel()
        {
            levelNum = Text.Text;

            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    x = c.Location.X;
                    y = c.Location.Y;

                    GameScreen.BrickType type = Form1.ConvertStringToBlockType(c.Text);

                    Bricks newBlock = new Bricks(x, y, type, GameScreen.brickImages[type]);
                    bricks.Add(newBlock);
                }
            }

            Level level = new Level();
            level.SaveLevel(levelNum, bricks);
        }
    }
}
