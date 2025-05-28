using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace BrickBreaker
{
    public partial class Form1 : Form
    {
        // List to store all player objects saved in the playerData XML file
        public static List<PlayerData> players = new List<PlayerData>();

        // Player object to store currently signed in player
        public static PlayerData player = new PlayerData();

        // Background music player
        public static System.Windows.Media.MediaPlayer backgroundPlayer = new System.Windows.Media.MediaPlayer();

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            // Load all saved players into a list
            players = player.LoadAllPlayerData();

            // Add method to loop audio to backgroundPlayer
            backgroundPlayer.MediaEnded += new EventHandler(backgroundPlayer_MediaEnded);


            // Play starting background music
            Form1.backgroundPlayer.Open(new Uri(Application.StartupPath + "/Resources/Sweden.mp3"));
            Form1.backgroundPlayer.Play();

        }

        // Loop audio
        public static void backgroundPlayer_MediaEnded(object sender, EventArgs e)
        {
            backgroundPlayer.Stop();
            backgroundPlayer.Play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the program centred on the Login Screen
            ChangeScreen(this, new LoginScreen());
        }

        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f;

            if (sender is Form)
            {
                f = (Form)sender;
            }
            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current);
            }

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);
            f.Controls.Add(next);
            next.Focus();
        }
    }
}
