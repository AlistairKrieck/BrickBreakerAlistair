using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace BrickBreaker
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the program centred on the Menu Screen
            MenuScreen ms = new MenuScreen();

            //Fill usercontrol to entire screen
            //ms.Dock = DockStyle.Fill;
            this.Controls.Add(ms);

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }

        public static GameScreen.BrickType ConvertStringToBlockType(string toConvert)
        {
            GameScreen.BrickType type;

            switch (toConvert)
            {
                case "grass":
                case "Grass":
                    type = GameScreen.BrickType.Grass;
                    break;

                case "dirt":
                case "Dirt":
                    type = GameScreen.BrickType.Dirt;
                    break;

                case "cobblestone":
                case "stone":
                case "Stone":
                    type = GameScreen.BrickType.Stone;
                    break;

                case "deepslate":
                case "Deepslate":
                    type = GameScreen.BrickType.Deepslate;
                    break;

                case "bedrock":
                case "Bedrock":
                    type = GameScreen.BrickType.Bedrock;
                    break;

                default:
                    type = GameScreen.BrickType.Dirt;
                    break;
            }

            return type;
        }

    }
}
