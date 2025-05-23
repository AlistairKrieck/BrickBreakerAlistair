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
    public partial class LogInScreen : UserControl
    {
        // Array of "watermark text" displayed in each input box when they are empty
        string[] watermarks = new string[] { "Enter Username...", "Enter Password..." };

        public LogInScreen()
        {
            InitializeComponent();

            // Prevent the input boxes from being automatically focused
            this.ActiveControl = titleLabel;
        }


        private void signInButton_Click(object sender, EventArgs e)
        {
            try
            {
                // If inputs are valid, store each in a string
                string username = usernameInput.Text;
                string password = passwordInput.Text;

                // Array to hold all inputs
                string[] inputs = { username, password };


                // If any of the input boxes still hold the watermark, inform user they are empty
                if (watermarks.Intersect(inputs).Any())
                {
                    signInButton.Text = "Not All Inputs Filled";
                }

                // If no saved player's usernames match the input, inform the player
                else if (!Form1.players.Any(p => p.username == username))
                {
                    signInButton.Text = "Incorrect Username";
                }

                // Inform user if username exists but password was incorrect
                else if (Form1.players.Any(p => p.username == username && p.password != password))
                {
                    signInButton.Text = "Incorrect Password";
                }

                // If no errors are met, store user as the signed in player and go to main menu
                else
                {
                    // Update player object to hold signed in player's data
                    Form1.player = Form1.players.Find(p => p.username == username && p.password == password);

                    // Go to main menu on succesful sign in
                    Form1.ChangeScreen(this, new MenuScreen());
                }
            }

            catch
            {
                // Inform user if their inputs are invalid
                signInButton.Text = "Invalid Username or Password";
            }
        }


        // Removes watermark text from input boxes when the box is selected
        private void ClearWatermarkOnEnter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;

            if (watermarks.Contains(tb.Text))
            {
                tb.ForeColor = Color.Black;
                tb.Text = "";
            }
        }

        //Show watermark text if input is deselected and empty
        private void ShowWatermarkOnLeave(object sender, EventArgs e)
        {
            // Store entered textbox in an object
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
                        tb.Text = "Enter Username...";
                        break;

                    case "passwordInput":
                        tb.Text = "Enter Password...";
                        break;
                }
            }
        }


        // Reset text on button when deselected
        private void signInButton_Leave(object sender, EventArgs e)
        {
            signInButton.Text = "Sign In";
        }

        // Deselect the input boxes when user clicks off of them
        private void LogInScreen_Click(object sender, EventArgs e)
        {
            this.ActiveControl = titleLabel;
        }


        // Go to account creation screen
        private void createAccountButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new CreateAccountScreen());
        }
    }
}
