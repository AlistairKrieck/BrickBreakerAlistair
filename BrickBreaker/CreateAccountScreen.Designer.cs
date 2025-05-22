namespace BrickBreaker
{
    partial class CreateAccountScreen
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
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.confirmPasswordInput = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameInput
            // 
            this.usernameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.usernameInput.ForeColor = System.Drawing.Color.Black;
            this.usernameInput.Location = new System.Drawing.Point(297, 204);
            this.usernameInput.MaxLength = 8;
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(273, 30);
            this.usernameInput.TabIndex = 5;
            this.usernameInput.Text = "Enter New Username...";
            this.usernameInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // passwordInput
            // 
            this.passwordInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.passwordInput.ForeColor = System.Drawing.Color.Black;
            this.passwordInput.Location = new System.Drawing.Point(297, 261);
            this.passwordInput.MaxLength = 8;
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(273, 30);
            this.passwordInput.TabIndex = 6;
            this.passwordInput.Text = "Enter New Password...";
            this.passwordInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // confirmPasswordInput
            // 
            this.confirmPasswordInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.confirmPasswordInput.ForeColor = System.Drawing.Color.Black;
            this.confirmPasswordInput.Location = new System.Drawing.Point(297, 297);
            this.confirmPasswordInput.MaxLength = 8;
            this.confirmPasswordInput.Name = "confirmPasswordInput";
            this.confirmPasswordInput.Size = new System.Drawing.Size(273, 30);
            this.confirmPasswordInput.TabIndex = 7;
            this.confirmPasswordInput.Text = "Confirm Password...";
            this.confirmPasswordInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.White;
            this.submitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.submitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.submitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.submitButton.Location = new System.Drawing.Point(277, 374);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(314, 78);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(216, 36);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(450, 116);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "Create New Account";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreateAccountScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.confirmPasswordInput);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.usernameInput);
            this.Name = "CreateAccountScreen";
            this.Size = new System.Drawing.Size(854, 542);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.TextBox confirmPasswordInput;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label titleLabel;
    }
}
