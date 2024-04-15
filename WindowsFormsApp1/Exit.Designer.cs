namespace WindowsFormsApp1
{
    partial class Exit
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exit));
            this.QUIT = new System.Windows.Forms.Button();
            this.REBOOT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // QUIT
            // 
            this.QUIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QUIT.ForeColor = System.Drawing.Color.White;
            this.QUIT.Image = global::WindowsFormsApp1.Properties.Resources.exit_small;
            this.QUIT.Location = new System.Drawing.Point(12, 21);
            this.QUIT.MaximumSize = new System.Drawing.Size(135, 153);
            this.QUIT.MinimumSize = new System.Drawing.Size(135, 153);
            this.QUIT.Name = "QUIT";
            this.QUIT.Size = new System.Drawing.Size(135, 153);
            this.QUIT.TabIndex = 0;
            this.QUIT.Text = " EXIT";
            this.QUIT.UseVisualStyleBackColor = true;
            this.QUIT.Click += new System.EventHandler(this.QUIT_Click);
            // 
            // REBOOT
            // 
            this.REBOOT.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.REBOOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REBOOT.Image = global::WindowsFormsApp1.Properties.Resources.reboot_small;
            this.REBOOT.Location = new System.Drawing.Point(165, 21);
            this.REBOOT.Name = "REBOOT";
            this.REBOOT.Size = new System.Drawing.Size(151, 153);
            this.REBOOT.TabIndex = 1;
            this.REBOOT.Text = "RESET";
            this.REBOOT.UseVisualStyleBackColor = true;
            // 
            // Exit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(340, 202);
            this.Controls.Add(this.REBOOT);
            this.Controls.Add(this.QUIT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(356, 241);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(356, 241);
            this.Name = "Exit";
            this.Text = "Exit";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button QUIT;
        private System.Windows.Forms.Button REBOOT;
    }
}