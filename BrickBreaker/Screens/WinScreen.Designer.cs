namespace BrickBreaker
{
    partial class WinScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinScreen));
            this.mainMenuButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.playerScoreLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.playNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenuButton
            // 
            this.mainMenuButton.BackColor = System.Drawing.Color.Transparent;
            this.mainMenuButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainMenuButton.BackgroundImage")));
            this.mainMenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mainMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mainMenuButton.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.mainMenuButton.Location = new System.Drawing.Point(36, 556);
            this.mainMenuButton.Name = "mainMenuButton";
            this.mainMenuButton.Size = new System.Drawing.Size(160, 60);
            this.mainMenuButton.TabIndex = 8;
            this.mainMenuButton.Text = "Main Menu";
            this.mainMenuButton.UseVisualStyleBackColor = false;
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.Transparent;
            this.quitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quitButton.BackgroundImage")));
            this.quitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.quitButton.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.quitButton.Location = new System.Drawing.Point(858, 556);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(160, 60);
            this.quitButton.TabIndex = 9;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = false;
            // 
            // playerScoreLabel
            // 
            this.playerScoreLabel.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerScoreLabel.ForeColor = System.Drawing.Color.Yellow;
            this.playerScoreLabel.Location = new System.Drawing.Point(911, 174);
            this.playerScoreLabel.Name = "playerScoreLabel";
            this.playerScoreLabel.Size = new System.Drawing.Size(127, 42);
            this.playerScoreLabel.TabIndex = 11;
            this.playerScoreLabel.Text = "0";
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(797, 174);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(127, 42);
            this.scoreLabel.TabIndex = 10;
            this.scoreLabel.Text = "Score:";
            // 
            // playNameLabel
            // 
            this.playNameLabel.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playNameLabel.ForeColor = System.Drawing.Color.Yellow;
            this.playNameLabel.Location = new System.Drawing.Point(764, 132);
            this.playNameLabel.Name = "playNameLabel";
            this.playNameLabel.Size = new System.Drawing.Size(221, 42);
            this.playNameLabel.TabIndex = 12;
            this.playNameLabel.Text = "Player Name";
            this.playNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WinScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.playNameLabel);
            this.Controls.Add(this.playerScoreLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.mainMenuButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WinScreen";
            this.Size = new System.Drawing.Size(1068, 678);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mainMenuButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label playerScoreLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label playNameLabel;
    }
}
