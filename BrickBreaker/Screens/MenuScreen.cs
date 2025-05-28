using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
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

            // Play background music
            Form1.backgroundPlayer.Open(new Uri(Application.StartupPath + "/Resources/Minecraft.mp3"));
            Form1.backgroundPlayer.Play();

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
            // Reset saved player
            Form1.player = new PlayerData();

            Form1.ChangeScreen(this, new LoginScreen());


            // Replay starting background music
            // Playing this here means it doesn't have to be run on load for login screen and create account screen,
            // stopping it from replaying when you switch between them
            Form1.backgroundPlayer.Open(new Uri(Application.StartupPath + "/Resources/Sweden.mp3"));
            Form1.backgroundPlayer.Play();
        }

        private void leaderboardButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new Screens.LeaderboardScreen());
        }
    }
}
