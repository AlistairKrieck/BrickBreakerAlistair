using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();

            // Display signed in user
            usernameLabel.Text = $"Signed in as \"{Form1.player.username}\"";
        }

        // Close the application
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Go to the game screen
        private void playButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }

        // Go to the level designer screen
        private void saveLevel_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new LevelDesign());
        }        

        // Reset signed in player to a blank and go to log in screen
        private void signOutButton_Click(object sender, EventArgs e)
        {
            Form1.player = new PlayerData();

            Form1.ChangeScreen(this, new LogInScreen());
        }
    }
}
