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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccountScreen));
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.confirmPasswordInput = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.logInButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameInput
            // 
            this.usernameInput.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameInput.ForeColor = System.Drawing.Color.Black;
            this.usernameInput.Location = new System.Drawing.Point(405, 191);
            this.usernameInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usernameInput.MaxLength = 8;
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(363, 36);
            this.usernameInput.TabIndex = 5;
            this.usernameInput.Text = "Enter New Username...";
            this.usernameInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.usernameInput.Enter += new System.EventHandler(this.ClearWatermarkOnEnter);
            this.usernameInput.Leave += new System.EventHandler(this.ShowWatermarkOnLeave);
            // 
            // passwordInput
            // 
            this.passwordInput.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordInput.ForeColor = System.Drawing.Color.Black;
            this.passwordInput.Location = new System.Drawing.Point(405, 261);
            this.passwordInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passwordInput.MaxLength = 8;
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(363, 36);
            this.passwordInput.TabIndex = 6;
            this.passwordInput.Text = "Enter New Password...";
            this.passwordInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordInput.Enter += new System.EventHandler(this.ClearWatermarkOnEnter);
            this.passwordInput.Leave += new System.EventHandler(this.ShowWatermarkOnLeave);
            // 
            // confirmPasswordInput
            // 
            this.confirmPasswordInput.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordInput.ForeColor = System.Drawing.Color.Black;
            this.confirmPasswordInput.Location = new System.Drawing.Point(405, 305);
            this.confirmPasswordInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.confirmPasswordInput.MaxLength = 8;
            this.confirmPasswordInput.Name = "confirmPasswordInput";
            this.confirmPasswordInput.Size = new System.Drawing.Size(363, 36);
            this.confirmPasswordInput.TabIndex = 7;
            this.confirmPasswordInput.Text = "Confirm Password...";
            this.confirmPasswordInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.confirmPasswordInput.Enter += new System.EventHandler(this.ClearWatermarkOnEnter);
            this.confirmPasswordInput.Leave += new System.EventHandler(this.ShowWatermarkOnLeave);
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.White;
            this.submitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.submitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.submitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(379, 400);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(419, 96);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            this.submitButton.Leave += new System.EventHandler(this.submitButton_Leave);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(287, 54);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(600, 143);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Create New Account";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logInButton
            // 
            this.logInButton.BackColor = System.Drawing.Color.White;
            this.logInButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.logInButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.logInButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.logInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logInButton.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logInButton.ForeColor = System.Drawing.Color.Black;
            this.logInButton.Location = new System.Drawing.Point(412, 521);
            this.logInButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(345, 52);
            this.logInButton.TabIndex = 12;
            this.logInButton.Text = "Already Have an Account?";
            this.logInButton.UseVisualStyleBackColor = false;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // CreateAccountScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.logInButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.confirmPasswordInput);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.usernameInput);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CreateAccountScreen";
            this.Size = new System.Drawing.Size(1139, 667);
            this.Click += new System.EventHandler(this.CreateAccountScreen_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.TextBox confirmPasswordInput;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button logInButton;
    }
}
