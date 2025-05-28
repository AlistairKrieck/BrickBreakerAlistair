using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class WinScreen : UserControl
    {
        public WinScreen()
        {
            InitializeComponent();

            playerScoreLabel.Text = Form1.player.score.ToString();
            playNameLabel.Text = Form1.player.username;

            // Play win sound effect
            SoundPlayer player = new SoundPlayer(Properties.Resources.winSound);
            player.Play();


            // Play background music
            Form1.backgroundPlayer.Open(new Uri(Application.StartupPath + "/Resources/Precipice.mp3"));
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
