namespace BrickBreaker
{
    partial class LogInScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInScreen));
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.signInButton = new System.Windows.Forms.Button();
            this.createAccountButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordInput
            // 
            this.passwordInput.BackColor = System.Drawing.Color.White;
            this.passwordInput.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordInput.ForeColor = System.Drawing.Color.Black;
            this.passwordInput.Location = new System.Drawing.Point(380, 268);
            this.passwordInput.Margin = new System.Windows.Forms.Padding(4);
            this.passwordInput.MaxLength = 8;
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(363, 36);
            this.passwordInput.TabIndex = 8;
            this.passwordInput.Text = "Enter Password...";
            this.passwordInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordInput.Enter += new System.EventHandler(this.ClearWatermarkOnEnter);
            this.passwordInput.Leave += new System.EventHandler(this.ShowWatermarkOnLeave);
            // 
            // usernameInput
            // 
            this.usernameInput.BackColor = System.Drawing.Color.White;
            this.usernameInput.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameInput.ForeColor = System.Drawing.Color.Black;
            this.usernameInput.Location = new System.Drawing.Point(380, 208);
            this.usernameInput.Margin = new System.Windows.Forms.Padding(4);
            this.usernameInput.MaxLength = 8;
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(363, 36);
            this.usernameInput.TabIndex = 7;
            this.usernameInput.Text = "Enter Username...";
            this.usernameInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.usernameInput.Enter += new System.EventHandler(this.ClearWatermarkOnEnter);
            this.usernameInput.Leave += new System.EventHandler(this.ShowWatermarkOnLeave);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(265, 62);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(600, 143);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "Sign Into Your Account";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signInButton
            // 
            this.signInButton.BackColor = System.Drawing.Color.White;
            this.signInButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.signInButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.signInButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.signInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signInButton.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInButton.Location = new System.Drawing.Point(355, 334);
            this.signInButton.Margin = new System.Windows.Forms.Padding(4);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(419, 96);
            this.signInButton.TabIndex = 10;
            this.signInButton.Text = "Sign In";
            this.signInButton.UseVisualStyleBackColor = false;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            this.signInButton.Leave += new System.EventHandler(this.signInButton_Leave);
            // 
            // createAccountButton
            // 
            this.createAccountButton.BackColor = System.Drawing.Color.White;
            this.createAccountButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.createAccountButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.createAccountButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.createAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createAccountButton.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createAccountButton.Location = new System.Drawing.Point(415, 449);
            this.createAccountButton.Margin = new System.Windows.Forms.Padding(4);
            this.createAccountButton.Name = "createAccountButton";
            this.createAccountButton.Size = new System.Drawing.Size(284, 52);
            this.createAccountButton.TabIndex = 11;
            this.createAccountButton.Text = "Don\'t Have an Account?";
            this.createAccountButton.UseVisualStyleBackColor = false;
            this.createAccountButton.Click += new System.EventHandler(this.createAccountButton_Click);
            // 
            // LogInScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.createAccountButton);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.usernameInput);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LogInScreen";
            this.Size = new System.Drawing.Size(1139, 667);
            this.Click += new System.EventHandler(this.LogInScreen_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.Button createAccountButton;
    }
}
