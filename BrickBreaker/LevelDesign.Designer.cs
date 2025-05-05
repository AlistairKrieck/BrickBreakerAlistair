namespace BrickBreaker
{
    partial class LevelDesign
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
            this.block1 = new System.Windows.Forms.Button();
            this.block2 = new System.Windows.Forms.Button();
            this.Text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // block1
            // 
            this.block1.Location = new System.Drawing.Point(15, 332);
            this.block1.Name = "block1";
            this.block1.Size = new System.Drawing.Size(127, 38);
            this.block1.TabIndex = 0;
            this.block1.Text = "1";
            this.block1.UseVisualStyleBackColor = true;
            // 
            // block2
            // 
            this.block2.Location = new System.Drawing.Point(172, 332);
            this.block2.Name = "block2";
            this.block2.Size = new System.Drawing.Size(127, 38);
            this.block2.TabIndex = 1;
            this.block2.Text = "1";
            this.block2.UseVisualStyleBackColor = true;
            // 
            // Text
            // 
            this.Text.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Text.Location = new System.Drawing.Point(63, 45);
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(416, 195);
            this.Text.TabIndex = 2;
            this.Text.Text = "label1";
            // 
            // LevelDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.Text);
            this.Controls.Add(this.block2);
            this.Controls.Add(this.block1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LevelDesign";
            this.Size = new System.Drawing.Size(1067, 677);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button block1;
        private System.Windows.Forms.Button block2;
        private System.Windows.Forms.Label Text;
    }
}
