namespace WindowsFormsApp1
{
    partial class Acerca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acerca));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelVERSION = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCUSTOMER = new System.Windows.Forms.TextBox();
            this.textBoxRELEASE = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.NCR_logo_new;
            this.pictureBox1.InitialImage = global::WindowsFormsApp1.Properties.Resources.NCR_logo_new;
            this.pictureBox1.Location = new System.Drawing.Point(16, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelVERSION
            // 
            this.labelVERSION.AutoSize = true;
            this.labelVERSION.Location = new System.Drawing.Point(423, 270);
            this.labelVERSION.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVERSION.Name = "labelVERSION";
            this.labelVERSION.Size = new System.Drawing.Size(53, 16);
            this.labelVERSION.TabIndex = 1;
            this.labelVERSION.Text = "Version";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 270);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "2023 NCR® Todos los derechos reservados (JM230603 )";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Imagen soportada:";
            // 
            // textBoxCUSTOMER
            // 
            this.textBoxCUSTOMER.Enabled = false;
            this.textBoxCUSTOMER.Location = new System.Drawing.Point(289, 74);
            this.textBoxCUSTOMER.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCUSTOMER.Name = "textBoxCUSTOMER";
            this.textBoxCUSTOMER.Size = new System.Drawing.Size(113, 22);
            this.textBoxCUSTOMER.TabIndex = 4;
            // 
            // textBoxRELEASE
            // 
            this.textBoxRELEASE.Enabled = false;
            this.textBoxRELEASE.Location = new System.Drawing.Point(289, 106);
            this.textBoxRELEASE.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRELEASE.Name = "textBoxRELEASE";
            this.textBoxRELEASE.Size = new System.Drawing.Size(188, 22);
            this.textBoxRELEASE.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(349, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Se puede utilizar tanto en tienda como en Staging (offline).";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(258, 32);
            this.label5.TabIndex = 6;
            this.label5.Text = "Asistente de configuración preconfigurado\r\n  para el entorno siguiente:";
            // 
            // Acerca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 287);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxRELEASE);
            this.Controls.Add(this.textBoxCUSTOMER);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelVERSION);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(511, 334);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(511, 294);
            this.Name = "Acerca";
            this.Text = "Acerca de...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelVERSION;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCUSTOMER;
        private System.Windows.Forms.TextBox textBoxRELEASE;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}