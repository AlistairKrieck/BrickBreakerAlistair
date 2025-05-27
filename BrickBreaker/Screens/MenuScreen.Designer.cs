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
            this.playButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.saveLevel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.leaderBoardOutput = new System.Windows.Forms.GroupBox();
            this.lbPlayerOutput = new System.Windows.Forms.Label();
            this.lb10Output = new System.Windows.Forms.Label();
            this.lb9Output = new System.Windows.Forms.Label();
            this.lb8Output = new System.Windows.Forms.Label();
            this.lb7Output = new System.Windows.Forms.Label();
            this.lb6Output = new System.Windows.Forms.Label();
            this.lb5Output = new System.Windows.Forms.Label();
            this.lb4Output = new System.Windows.Forms.Label();
            this.lb3Output = new System.Windows.Forms.Label();
            this.lb2Output = new System.Windows.Forms.Label();
            this.lb1Output = new System.Windows.Forms.Label();
            this.signOutButton = new System.Windows.Forms.Button();
            this.leaderBoardOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.White;
            this.playButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.playButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(39, 59);
            this.playButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(242, 96);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.White;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(39, 164);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(242, 96);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // saveLevel
            // 
            this.saveLevel.BackColor = System.Drawing.Color.White;
            this.saveLevel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.saveLevel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.saveLevel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.saveLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveLevel.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveLevel.Location = new System.Drawing.Point(39, 268);
            this.saveLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveLevel.Name = "saveLevel";
            this.saveLevel.Size = new System.Drawing.Size(242, 96);
            this.saveLevel.TabIndex = 2;
            this.saveLevel.Text = "Save Level";
            this.saveLevel.UseVisualStyleBackColor = false;
            this.saveLevel.Click += new System.EventHandler(this.saveLevel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // usernameLabel
            // 
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.usernameLabel.ForeColor = System.Drawing.Color.White;
            this.usernameLabel.Location = new System.Drawing.Point(56, 390);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(285, 29);
            this.usernameLabel.TabIndex = 4;
            this.usernameLabel.Text = "Signed in as:";
            // 
            // leaderBoardOutput
            // 
            this.leaderBoardOutput.Controls.Add(this.lbPlayerOutput);
            this.leaderBoardOutput.Controls.Add(this.lb10Output);
            this.leaderBoardOutput.Controls.Add(this.lb9Output);
            this.leaderBoardOutput.Controls.Add(this.lb8Output);
            this.leaderBoardOutput.Controls.Add(this.lb7Output);
            this.leaderBoardOutput.Controls.Add(this.lb6Output);
            this.leaderBoardOutput.Controls.Add(this.lb5Output);
            this.leaderBoardOutput.Controls.Add(this.lb4Output);
            this.leaderBoardOutput.Controls.Add(this.lb3Output);
            this.leaderBoardOutput.Controls.Add(this.lb2Output);
            this.leaderBoardOutput.Controls.Add(this.lb1Output);
            this.leaderBoardOutput.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.leaderBoardOutput.ForeColor = System.Drawing.Color.White;
            this.leaderBoardOutput.Location = new System.Drawing.Point(675, 59);
            this.leaderBoardOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.leaderBoardOutput.Name = "leaderBoardOutput";
            this.leaderBoardOutput.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.leaderBoardOutput.Size = new System.Drawing.Size(354, 574);
            this.leaderBoardOutput.TabIndex = 5;
            this.leaderBoardOutput.TabStop = false;
            this.leaderBoardOutput.Text = "Leader Board";
            // 
            // lbPlayerOutput
            // 
            this.lbPlayerOutput.BackColor = System.Drawing.Color.Transparent;
            this.lbPlayerOutput.Enabled = false;
            this.lbPlayerOutput.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbPlayerOutput.ForeColor = System.Drawing.Color.White;
            this.lbPlayerOutput.Location = new System.Drawing.Point(8, 480);
            this.lbPlayerOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPlayerOutput.Name = "lbPlayerOutput";
            this.lbPlayerOutput.Size = new System.Drawing.Size(285, 29);
            this.lbPlayerOutput.TabIndex = 16;
            // 
            // lb10Output
            // 
            this.lb10Output.BackColor = System.Drawing.Color.Transparent;
            this.lb10Output.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lb10Output.ForeColor = System.Drawing.Color.White;
            this.lb10Output.Location = new System.Drawing.Point(8, 412);
            this.lb10Output.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb10Output.Name = "lb10Output";
            this.lb10Output.Size = new System.Drawing.Size(285, 29);
            this.lb10Output.TabIndex = 15;
            this.lb10Output.Text = "#1: ";
            // 
            // lb9Output
            // 
            this.lb9Output.BackColor = System.Drawing.Color.Transparent;
            this.lb9Output.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lb9Output.ForeColor = System.Drawing.Color.White;
            this.lb9Output.Location = new System.Drawing.Point(8, 375);
            this.lb9Output.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb9Output.Name = "lb9Output";
            this.lb9Output.Size = new System.Drawing.Size(285, 29);
            this.lb9Output.TabIndex = 14;
            this.lb9Output.Text = "#1: ";
            // 
            // lb8Output
            // 
            this.lb8Output.BackColor = System.Drawing.Color.Transparent;
            this.lb8Output.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lb8Output.ForeColor = System.Drawing.Color.White;
            this.lb8Output.Location = new System.Drawing.Point(8, 335);
            this.lb8Output.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb8Output.Name = "lb8Output";
            this.lb8Output.Size = new System.Drawing.Size(285, 29);
            this.lb8Output.TabIndex = 13;
            this.lb8Output.Text = "#1: ";
            // 
            // lb7Output
            // 
            this.lb7Output.BackColor = System.Drawing.Color.Transparent;
            this.lb7Output.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lb7Output.ForeColor = System.Drawing.Color.White;
            this.lb7Output.Location = new System.Drawing.Point(8, 298);
            this.lb7Output.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb7Output.Name = "lb7Output";
            this.lb7Output.Size = new System.Drawing.Size(285, 29);
            this.lb7Output.TabIndex = 12;
            this.lb7Output.Text = "#1: ";
            // 
            // lb6Output
            // 
            this.lb6Output.BackColor = System.Drawing.Color.Transparent;
            this.lb6Output.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lb6Output.ForeColor = System.Drawing.Color.White;
            this.lb6Output.Location = new System.Drawing.Point(8, 260);
            this.lb6Output.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb6Output.Name = "lb6Output";
            this.lb6Output.Size = new System.Drawing.Size(285, 29);
            this.lb6Output.TabIndex = 11;
            this.lb6Output.Text = "#1: ";
            // 
            // lb5Output
            // 
            this.lb5Output.BackColor = System.Drawing.Color.Transparent;
            this.lb5Output.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lb5Output.ForeColor = System.Drawing.Color.White;
            this.lb5Output.Location = new System.Drawing.Point(8, 222);
            this.lb5Output.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb5Output.Name = "lb5Output";
            this.lb5Output.Size = new System.Drawing.Size(285, 29);
            this.lb5Output.TabIndex = 10;
            this.lb5Output.Text = "#1: ";
            // 
            // lb4Output
            // 
            this.lb4Output.BackColor = System.Drawing.Color.Transparent;
            this.lb4Output.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lb4Output.ForeColor = System.Drawing.Color.White;
            this.lb4Output.Location = new System.Drawing.Point(8, 185);
            this.lb4Output.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb4Output.Name = "lb4Output";
            this.lb4Output.Size = new System.Drawing.Size(285, 29);
            this.lb4Output.TabIndex = 9;
            this.lb4Output.Text = "#1: ";
            // 
            // lb3Output
            // 
            this.lb3Output.BackColor = System.Drawing.Color.Transparent;
            this.lb3Output.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lb3Output.ForeColor = System.Drawing.Color.White;
            this.lb3Output.Location = new System.Drawing.Point(8, 139);
            this.lb3Output.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb3Output.Name = "lb3Output";
            this.lb3Output.Size = new System.Drawing.Size(285, 29);
            this.lb3Output.TabIndex = 8;
            this.lb3Output.Text = "#3: ";
            // 
            // lb2Output
            // 
            this.lb2Output.BackColor = System.Drawing.Color.Transparent;
            this.lb2Output.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lb2Output.ForeColor = System.Drawing.Color.White;
            this.lb2Output.Location = new System.Drawing.Point(8, 91);
            this.lb2Output.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb2Output.Name = "lb2Output";
            this.lb2Output.Size = new System.Drawing.Size(285, 29);
            this.lb2Output.TabIndex = 7;
            this.lb2Output.Text = "#2: ";
            // 
            // lb1Output
            // 
            this.lb1Output.BackColor = System.Drawing.Color.Transparent;
            this.lb1Output.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lb1Output.ForeColor = System.Drawing.Color.White;
            this.lb1Output.Location = new System.Drawing.Point(8, 44);
            this.lb1Output.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb1Output.Name = "lb1Output";
            this.lb1Output.Size = new System.Drawing.Size(285, 29);
            this.lb1Output.TabIndex = 6;
            this.lb1Output.Text = "#1: ";
            // 
            // signOutButton
            // 
            this.signOutButton.BackColor = System.Drawing.Color.White;
            this.signOutButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.signOutButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.signOutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.signOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signOutButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signOutButton.Location = new System.Drawing.Point(61, 434);
            this.signOutButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.signOutButton.Name = "signOutButton";
            this.signOutButton.Size = new System.Drawing.Size(179, 52);
            this.signOutButton.TabIndex = 12;
            this.signOutButton.Text = "Sign Out";
            this.signOutButton.UseVisualStyleBackColor = false;
            this.signOutButton.Click += new System.EventHandler(this.signOutButton_Click);
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.signOutButton);
            this.Controls.Add(this.leaderBoardOutput);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveLevel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.playButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(1068, 678);
            this.leaderBoardOutput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button saveLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.GroupBox leaderBoardOutput;
        private System.Windows.Forms.Label lb10Output;
        private System.Windows.Forms.Label lb9Output;
        private System.Windows.Forms.Label lb8Output;
        private System.Windows.Forms.Label lb7Output;
        private System.Windows.Forms.Label lb6Output;
        private System.Windows.Forms.Label lb5Output;
        private System.Windows.Forms.Label lb4Output;
        private System.Windows.Forms.Label lb3Output;
        private System.Windows.Forms.Label lb2Output;
        private System.Windows.Forms.Label lb1Output;
        private System.Windows.Forms.Label lbPlayerOutput;
        private System.Windows.Forms.Button signOutButton;
    }
}
