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
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();

            playerScoreLabel.Text = Form1.player.score.ToString();
            playerNameLabel.Text = Form1.player.username;

            // Play background music
            Form1.backgroundPlayer.Open(new Uri(Application.StartupPath + "/Resources/Eleven.mp3"));
            Form1.backgroundPlayer.Play();
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
