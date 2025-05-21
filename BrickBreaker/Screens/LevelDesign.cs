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
            Application.Exit();
        }

        string levelNum;

        public LevelDesign()
        {
            InitializeComponent();
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

                    string type = c.Text;

                    Bricks newBlock = new Bricks(x, y, type, GameScreen.brickImages[type]);
                    bricks.Add(newBlock);
                }
            }

            LevelLoader level = new LevelLoader();
            level.SaveLevel(levelNum, bricks);
        }
    }
}
