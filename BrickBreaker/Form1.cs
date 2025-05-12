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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Make the form fullscreen
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the program with the Menu Screen docked to full screen
            MenuScreen ms = new MenuScreen();
            ms.Dock = DockStyle.Fill;

            this.Controls.Add(ms);
        }
    }
}
