using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BrickBreaker
{
    public partial class CreateAccountScreen : UserControl
    {
        List<PlayerData> list = new List<PlayerData>();

        public CreateAccountScreen()
        {
            InitializeComponent();

            list = PlayerData.LoadPlayerData();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string username = usernameInput.Text;
                string password = passwordInput.Text;
                string confirmedPassword = confirmPasswordInput.Text;


                if (confirmedPassword != password)
                {
                    submitButton.Text = "Passwords Do Not Match";
                }

                if (list.Contains(p => p.username == username))
                {

                }
            }

            catch
            {
                submitButton.Text = "Invalid Username or Password";
            }
        }

        public void temp()
        {
            List<PlayerData> list = new List<PlayerData>();
            list = PlayerData.LoadPlayerData();
        }


    }
}
