namespace BrickBreaker
{
    partial class GameScreen
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.livesLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // livesLabel
            // 
            this.livesLabel.AutoSize = true;
            this.livesLabel.BackColor = System.Drawing.Color.Black;
            this.livesLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.livesLabel.Location = new System.Drawing.Point(292, 66);
            this.livesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.livesLabel.Name = "livesLabel";
            this.livesLabel.Size = new System.Drawing.Size(31, 15);
            this.livesLabel.TabIndex = 0;
            this.livesLabel.Text = "lives";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Black;
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.scoreLabel.Location = new System.Drawing.Point(922, 66);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(37, 15);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "score";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.livesLabel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(1068, 678);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label livesLabel;
        private System.Windows.Forms.Label scoreLabel;
    }
}
