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
        private void saveLabel_Click(object sender, EventArgs e)
        {
            // Save the level to an XML file and shut down the program for ease of designing
            SaveLevel();
            Application.Exit();
        }

        public LevelDesign()
        {
            InitializeComponent();
        }

        private void SaveLevel()
        {
            List<Bricks> bricks = new List<Bricks>();

            // Get level number (format level[n]) from level name label
            string levelNum = levelNameLabel.Text;

            // Create new brick objects for each button placed in the designer and add them to a list
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    // Get brick info from each button
                    int x = c.Location.X;
                    int y = c.Location.Y;
                    string type = c.Text;

                    //Create a new brick object with the button info and add it to a list
                    Bricks newBrick = new Bricks(x, y, type, GameScreen.brickImages[type]);
                    bricks.Add(newBrick);
                }
            }

            // Create a new level loader object
            LevelLoader level = new LevelLoader();

            // Save the list of bricks into an XML file named after the level number
            level.SaveLevel(levelNum, bricks);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
