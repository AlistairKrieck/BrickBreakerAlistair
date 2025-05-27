namespace BrickBreaker
{
    partial class MenuScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuScreen));
            this.playButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.saveLevel = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.signOutButton = new System.Windows.Forms.Button();
            this.leaderboardButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.Transparent;
            this.playButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playButton.BackgroundImage")));
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.playButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.playButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.playButton.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.playButton.Location = new System.Drawing.Point(325, 227);
            this.playButton.Margin = new System.Windows.Forms.Padding(4);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(405, 40);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitButton.BackgroundImage")));
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.exitButton.Location = new System.Drawing.Point(325, 419);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(405, 40);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // saveLevel
            // 
            this.saveLevel.BackColor = System.Drawing.Color.Transparent;
            this.saveLevel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("saveLevel.BackgroundImage")));
            this.saveLevel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveLevel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.saveLevel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.saveLevel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.saveLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveLevel.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveLevel.ForeColor = System.Drawing.Color.Gainsboro;
            this.saveLevel.Location = new System.Drawing.Point(325, 275);
            this.saveLevel.Margin = new System.Windows.Forms.Padding(4);
            this.saveLevel.Name = "saveLevel";
            this.saveLevel.Size = new System.Drawing.Size(405, 40);
            this.saveLevel.TabIndex = 2;
            this.saveLevel.Text = "Save Level";
            this.saveLevel.UseVisualStyleBackColor = false;
            this.saveLevel.Click += new System.EventHandler(this.saveLevel_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.usernameLabel.Location = new System.Drawing.Point(765, 632);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(285, 29);
            this.usernameLabel.TabIndex = 4;
            this.usernameLabel.Text = "Signed in as:";
            // 
            // signOutButton
            // 
            this.signOutButton.BackColor = System.Drawing.Color.Transparent;
            this.signOutButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("signOutButton.BackgroundImage")));
            this.signOutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.signOutButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.signOutButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.signOutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.signOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.signOutButton.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signOutButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.signOutButton.Location = new System.Drawing.Point(325, 323);
            this.signOutButton.Margin = new System.Windows.Forms.Padding(4);
            this.signOutButton.Name = "signOutButton";
            this.signOutButton.Size = new System.Drawing.Size(405, 40);
            this.signOutButton.TabIndex = 12;
            this.signOutButton.Text = "Sign Out";
            this.signOutButton.UseVisualStyleBackColor = false;
            this.signOutButton.Click += new System.EventHandler(this.signOutButton_Click);
            // 
            // leaderboardButton
            // 
            this.leaderboardButton.BackColor = System.Drawing.Color.Transparent;
            this.leaderboardButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leaderboardButton.BackgroundImage")));
            this.leaderboardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.leaderboardButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.leaderboardButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.leaderboardButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.leaderboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.leaderboardButton.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboardButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.leaderboardButton.Location = new System.Drawing.Point(325, 371);
            this.leaderboardButton.Margin = new System.Windows.Forms.Padding(4);
            this.leaderboardButton.Name = "leaderboardButton";
            this.leaderboardButton.Size = new System.Drawing.Size(405, 40);
            this.leaderboardButton.TabIndex = 13;
            this.leaderboardButton.Text = "Leaderboard";
            this.leaderboardButton.UseVisualStyleBackColor = false;
            this.leaderboardButton.Click += new System.EventHandler(this.leaderboardButton_Click);
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.leaderboardButton);
            this.Controls.Add(this.signOutButton);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.saveLevel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.playButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(1068, 678);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button saveLevel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button signOutButton;
        private System.Windows.Forms.Button leaderboardButton;
    }
}
