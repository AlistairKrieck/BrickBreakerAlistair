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

            // Display leader board
            ShowLeaderBoard();
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

        // Output and display the top 10 players by score to the leader board
        private void ShowLeaderBoard()
        {
            // Number of players listed on the leader board
            int lbPositions = 10;

            // List of labels to store the outputs for each position on the leader board
            List<Label> lbOutputs = new List<Label>();

            // Add all of the labels inside of the leader board to the list
            foreach (Control c in leaderBoardOutput.Controls)
            {
                if (c is Label)
                {
                    lbOutputs.Add((Label)c);
                }
            }

            // Order output labels by their name (lb10Output, lb9Output...)
            lbOutputs.OrderBy(l => l.Name);

            // Fix ordering (lb1Output, lb2Output...)
            lbOutputs.Reverse();

            // Add all saved players to a new list
            List<PlayerData> lb = Form1.players;

            // Order list of players by their score from highest to lowest
            lb.OrderByDescending(p => p.score);

            // Write player names and scores to their respective position on the leader board
            for (int i = 0; i < lbPositions; i++)
            {
                // If the currently signed in player is not on the leader board, output their ranking to a seperate label
                if (!lb.Take(lbPositions).Contains(Form1.player))
                {
                    lbPlayerOutput.Text = $"#{lb.FindIndex(p => p == Form1.player) + 1}: {Form1.player.username}, {Form1.player.score}";
                }

                // If the currently signed in player is on the leader board, hide the extra label
                else
                {
                    lbPlayerOutput.Text = "";
                }


                // Try to fill all positions on the leader board
                try
                {
                    lbOutputs[i].Text = $"#{i + 1}: {lb[i].username}, {lb[i].score}";
                }

                // If too few players are saved, fill the rest of the leader board with blanks
                catch
                {
                    lbOutputs[i].Text = $"#{i + 1}: Up For Grabs!";
                }

            }

        }

        // Reset signed in player to a blank and go to log in screen
        private void signOutButton_Click(object sender, EventArgs e)
        {
            Form1.player = new PlayerData();

            Form1.ChangeScreen(this, new LogInScreen());
        }
    }
}
