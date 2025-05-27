namespace BrickBreaker
{
    partial class GameOverScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverScreen));
            this.mainMenuButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.playerScoreLabel = new System.Windows.Forms.Label();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenuButton
            // 
            this.mainMenuButton.BackColor = System.Drawing.Color.Transparent;
            this.mainMenuButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainMenuButton.BackgroundImage")));
            this.mainMenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mainMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mainMenuButton.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.mainMenuButton.Location = new System.Drawing.Point(112, 418);
            this.mainMenuButton.Name = "mainMenuButton";
            this.mainMenuButton.Size = new System.Drawing.Size(840, 79);
            this.mainMenuButton.TabIndex = 0;
            this.mainMenuButton.Text = "Main Menu";
            this.mainMenuButton.UseVisualStyleBackColor = false;
            this.mainMenuButton.Click += new System.EventHandler(this.mainMenuButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.Transparent;
            this.quitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quitButton.BackgroundImage")));
            this.quitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.quitButton.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.quitButton.Location = new System.Drawing.Point(112, 518);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(840, 79);
            this.quitButton.TabIndex = 1;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(446, 239);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(127, 42);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.Text = "Score:";
            // 
            // playerScoreLabel
            // 
            this.playerScoreLabel.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerScoreLabel.ForeColor = System.Drawing.Color.Yellow;
            this.playerScoreLabel.Location = new System.Drawing.Point(560, 239);
            this.playerScoreLabel.Name = "playerScoreLabel";
            this.playerScoreLabel.Size = new System.Drawing.Size(127, 42);
            this.playerScoreLabel.TabIndex = 3;
            this.playerScoreLabel.Text = "0";
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameLabel.ForeColor = System.Drawing.Color.Yellow;
            this.playerNameLabel.Location = new System.Drawing.Point(394, 197);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(240, 42);
            this.playerNameLabel.TabIndex = 4;
            this.playerNameLabel.Text = "Player Name";
            this.playerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameOverScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.playerNameLabel);
            this.Controls.Add(this.playerScoreLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.mainMenuButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameOverScreen";
            this.Size = new System.Drawing.Size(1068, 678);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mainMenuButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label playerScoreLabel;
        private System.Windows.Forms.Label playerNameLabel;
    }
}
