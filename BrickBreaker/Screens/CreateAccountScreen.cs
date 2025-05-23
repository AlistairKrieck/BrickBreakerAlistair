using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BrickBreaker
{
    public partial class CreateAccountScreen : UserControl
    {
        // Array of "watermark text" displayed in each input box when they are empty
        string[] watermarks = new string[] { "Enter New Username...", "Enter New Password...", "Confirm Password..." };


        public CreateAccountScreen()
        {
            InitializeComponent();

            // Prevent the input boxes from being automatically focused
            this.ActiveControl = titleLabel;
        }


        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                // If inputs are valid, store each in a string
                string username = usernameInput.Text;
                string password = passwordInput.Text;
                string confirmedPassword = confirmPasswordInput.Text;

                // Array of all inputs
                string[] inputs = { username, password, confirmedPassword };

                // If any of the input boxes still hold the watermark, inform user that they are empty
                if (watermarks.Intersect(inputs).Any())
                {
                    submitButton.Text = "Not All Inputs Filled";
                }

                // Tell user if selected username has been used before
                else if (Form1.players.Any(p => p.username == username))
                {
                    submitButton.Text = "Username Taken";
                }

                // Tell user if passwords do not match
                else if (confirmedPassword != password)
                {
                    submitButton.Text = "Passwords Do Not Match";
                }

                // If no errors are met, save new player account to the playerData XML and set them as the signed in player
                else
                {
                    // Store inputs in a new player object
                    PlayerData player = new PlayerData(username, password);

                    // Save new player to the XML file storing all players
                    player.SavePlayerData();

                    // Update list of players to include new account
                    Form1.players = PlayerData.LoadPlayerData();

                    // Set signed in player to a new player object with the created accounts data
                    // Doing it this way instead of Form1.player = player fixes a bug in the main menu, where the player will be displayed on the leaderboard twice
                    Form1.player = Form1.players.Find(p => p.username == username && p.password == password);

                    // Go to main menu on valid character creation
                    Form1.ChangeScreen(this, new MenuScreen());
                }
            }

            catch
            {
                // Inform user if their inputs are invalid
                submitButton.Text = "Invalid Username or Password";
            }
        }

        // Reset text on the submit button when another object is selected
        private void submitButton_Leave(object sender, EventArgs e)
        {
            submitButton.Text = "Submit";
        }


        // Removes watermark text from input boxes when the box is selected
        private void ClearWatermarkOnEnter(object sender, EventArgs e)
        {
            // Store selected text box in an object
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;

            // If text is currently a watermark, clear text and set text colour to black
            if (watermarks.Contains(tb.Text))
            {
                tb.ForeColor = Color.Black;
                tb.Text = "";
            }
        }

        //Show watermark text if input is deselected and empty
        private void ShowWatermarkOnLeave(object sender, EventArgs e)
        {
            // Store selected text box in an object
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;

            // If the input is empty or null, re-display the watermark
            if (tb.Text == "" || tb.Text == null)
            {
                // Set text colour to silver to differentiate watermark from input
                tb.ForeColor = Color.Silver;

                // Get which text box was entered to show relevant watermark text
                switch (tb.Name)
                {
                    case "usernameInput":
                        tb.Text = "Enter New Username...";
                        break;

                    case "passwordInput":
                        tb.Text = "Enter New Password...";
                        break;

                    case "confirmPasswordInput":
                        tb.Text = "Confirm Password...";
                        break;
                }
            }
        }


        // Deselect the input boxes when user clicks off of them
        private void CreateAccountScreen_Click(object sender, EventArgs e)
        {
            this.ActiveControl = titleLabel;
        }

        // Go to log in screen
        private void logInButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new LogInScreen());
        }
    }
}
