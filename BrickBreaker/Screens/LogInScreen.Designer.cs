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
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.signInButton = new System.Windows.Forms.Button();
            this.createAccountButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordInput
            // 
            this.passwordInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.passwordInput.ForeColor = System.Drawing.Color.Silver;
            this.passwordInput.Location = new System.Drawing.Point(285, 218);
            this.passwordInput.MaxLength = 8;
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(273, 30);
            this.passwordInput.TabIndex = 8;
            this.passwordInput.Text = "Enter Password...";
            this.passwordInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordInput.Enter += new System.EventHandler(this.ClearWatermarkOnEnter);
            this.passwordInput.Leave += new System.EventHandler(this.ShowWatermarkOnLeave);
            // 
            // usernameInput
            // 
            this.usernameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.usernameInput.ForeColor = System.Drawing.Color.Silver;
            this.usernameInput.Location = new System.Drawing.Point(285, 169);
            this.usernameInput.MaxLength = 8;
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(273, 30);
            this.usernameInput.TabIndex = 7;
            this.usernameInput.Text = "Enter Username...";
            this.usernameInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.usernameInput.Enter += new System.EventHandler(this.ClearWatermarkOnEnter);
            this.usernameInput.Leave += new System.EventHandler(this.ShowWatermarkOnLeave);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(199, 50);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(450, 116);
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
            this.signInButton.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.signInButton.Location = new System.Drawing.Point(266, 271);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(314, 78);
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
            this.createAccountButton.Font = new System.Drawing.Font("Tahoma", 12F);
            this.createAccountButton.Location = new System.Drawing.Point(316, 364);
            this.createAccountButton.Name = "createAccountButton";
            this.createAccountButton.Size = new System.Drawing.Size(210, 42);
            this.createAccountButton.TabIndex = 11;
            this.createAccountButton.Text = "Don\'t Have an Account?";
            this.createAccountButton.UseVisualStyleBackColor = false;
            this.createAccountButton.Click += new System.EventHandler(this.createAccountButton_Click);
            // 
            // LogInScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.createAccountButton);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.usernameInput);
            this.Name = "LogInScreen";
            this.Size = new System.Drawing.Size(854, 542);
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
