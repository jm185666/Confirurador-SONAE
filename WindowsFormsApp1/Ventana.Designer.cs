using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBoxNCR = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSTORE = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSCO = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.textBoxNETMASK = new System.Windows.Forms.TextBox();
            this.textBoxGATEWAY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxHOSTNAME = new System.Windows.Forms.TextBox();
            this.checkBoxMaster = new System.Windows.Forms.CheckBox();
            this.buttonACERCA = new System.Windows.Forms.Button();
            this.groupBoxLane = new System.Windows.Forms.GroupBox();
            this.groupBoxMaster = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIPMaster = new System.Windows.Forms.TextBox();
            this.checkBoxWebFront = new System.Windows.Forms.CheckBox();
            this.checkBoxFilaUnica = new System.Windows.Forms.CheckBox();
            this.groupBoxFilaUnica = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxFilaUnica = new System.Windows.Forms.TextBox();
            this.buttonCONFIGURAR = new System.Windows.Forms.Button();
            this.buttonEXIT = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxLanesStore = new System.Windows.Forms.TextBox();
            this.textBoxIpFirstLane = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBoxHWType = new System.Windows.Forms.GroupBox();
            this.ss90 = new System.Windows.Forms.RadioButton();
            this.cashLess = new System.Windows.Forms.RadioButton();
            this.cash = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNCR)).BeginInit();
            this.groupBoxLane.SuspendLayout();
            this.groupBoxMaster.SuspendLayout();
            this.groupBoxFilaUnica.SuspendLayout();
            this.groupBoxHWType.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxNCR
            // 
            this.pictureBoxNCR.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNCR.Image")));
            this.pictureBoxNCR.Location = new System.Drawing.Point(10, 11);
            this.pictureBoxNCR.Name = "pictureBoxNCR";
            this.pictureBoxNCR.Size = new System.Drawing.Size(172, 50);
            this.pictureBoxNCR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNCR.TabIndex = 37;
            this.pictureBoxNCR.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.Location = new System.Drawing.Point(10, 69);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(172, 8);
            this.progressBar1.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Store";
            // 
            // textBoxSTORE
            // 
            this.textBoxSTORE.Location = new System.Drawing.Point(284, 12);
            this.textBoxSTORE.MaxLength = 4;
            this.textBoxSTORE.Name = "textBoxSTORE";
            this.textBoxSTORE.Size = new System.Drawing.Size(37, 20);
            this.textBoxSTORE.TabIndex = 0;
            this.textBoxSTORE.TextChanged += new System.EventHandler(this.TextBoxSTORE_TextChanged);
            this.textBoxSTORE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSTORE_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(189, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Lane";
            // 
            // textBoxSCO
            // 
            this.textBoxSCO.Location = new System.Drawing.Point(284, 37);
            this.textBoxSCO.MaxLength = 2;
            this.textBoxSCO.Name = "textBoxSCO";
            this.textBoxSCO.Size = new System.Drawing.Size(46, 20);
            this.textBoxSCO.TabIndex = 1;
            this.textBoxSCO.TextChanged += new System.EventHandler(this.TextBoxSCO_TextChanged);
            this.textBoxSCO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSCO_KeyPress);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(62, 29);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(81, 20);
            this.textBoxIP.TabIndex = 3;
            this.textBoxIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIP_KeyPress);
            // 
            // textBoxNETMASK
            // 
            this.textBoxNETMASK.Location = new System.Drawing.Point(62, 54);
            this.textBoxNETMASK.Name = "textBoxNETMASK";
            this.textBoxNETMASK.Size = new System.Drawing.Size(81, 20);
            this.textBoxNETMASK.TabIndex = 4;
            this.textBoxNETMASK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNETMASK_KeyPress);
            // 
            // textBoxGATEWAY
            // 
            this.textBoxGATEWAY.Location = new System.Drawing.Point(62, 76);
            this.textBoxGATEWAY.Name = "textBoxGATEWAY";
            this.textBoxGATEWAY.Size = new System.Drawing.Size(81, 20);
            this.textBoxGATEWAY.TabIndex = 5;
            this.textBoxGATEWAY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxGATEWAY_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label4.Location = new System.Drawing.Point(6, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "IP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label5.Location = new System.Drawing.Point(6, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Netmask";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label6.Location = new System.Drawing.Point(6, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Gateway";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Enabled = false;
            this.richTextBoxLog.HideSelection = false;
            this.richTextBoxLog.Location = new System.Drawing.Point(387, 12);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(233, 257);
            this.richTextBoxLog.TabIndex = 34;
            this.richTextBoxLog.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(188, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Hostname";
            // 
            // textBoxHOSTNAME
            // 
            this.textBoxHOSTNAME.Enabled = false;
            this.textBoxHOSTNAME.Location = new System.Drawing.Point(284, 61);
            this.textBoxHOSTNAME.Name = "textBoxHOSTNAME";
            this.textBoxHOSTNAME.Size = new System.Drawing.Size(99, 20);
            this.textBoxHOSTNAME.TabIndex = 2;
            // 
            // checkBoxMaster
            // 
            this.checkBoxMaster.AutoSize = true;
            this.checkBoxMaster.Location = new System.Drawing.Point(18, 213);
            this.checkBoxMaster.Name = "checkBoxMaster";
            this.checkBoxMaster.Size = new System.Drawing.Size(58, 17);
            this.checkBoxMaster.TabIndex = 43;
            this.checkBoxMaster.Text = "Master";
            this.checkBoxMaster.UseVisualStyleBackColor = true;
            this.checkBoxMaster.CheckedChanged += new System.EventHandler(this.checkBoxMaster_CheckedChanged_1);
            // 
            // buttonACERCA
            // 
            this.buttonACERCA.AutoSize = true;
            this.buttonACERCA.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonACERCA.FlatAppearance.BorderSize = 0;
            this.buttonACERCA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonACERCA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonACERCA.Image = ((System.Drawing.Image)(resources.GetObject("buttonACERCA.Image")));
            this.buttonACERCA.Location = new System.Drawing.Point(563, 355);
            this.buttonACERCA.Margin = new System.Windows.Forms.Padding(0);
            this.buttonACERCA.Name = "buttonACERCA";
            this.buttonACERCA.Size = new System.Drawing.Size(56, 51);
            this.buttonACERCA.TabIndex = 28;
            this.buttonACERCA.UseVisualStyleBackColor = false;
            this.buttonACERCA.Click += new System.EventHandler(this.ButtonACERCA_Click);
            // 
            // groupBoxLane
            // 
            this.groupBoxLane.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxLane.Controls.Add(this.label4);
            this.groupBoxLane.Controls.Add(this.textBoxIP);
            this.groupBoxLane.Controls.Add(this.label5);
            this.groupBoxLane.Controls.Add(this.textBoxNETMASK);
            this.groupBoxLane.Controls.Add(this.textBoxGATEWAY);
            this.groupBoxLane.Controls.Add(this.label6);
            this.groupBoxLane.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxLane.Location = new System.Drawing.Point(191, 154);
            this.groupBoxLane.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxLane.Name = "groupBoxLane";
            this.groupBoxLane.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxLane.Size = new System.Drawing.Size(161, 103);
            this.groupBoxLane.TabIndex = 30;
            this.groupBoxLane.TabStop = false;
            this.groupBoxLane.Text = "Lane Configuration";
            // 
            // groupBoxMaster
            // 
            this.groupBoxMaster.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBoxMaster.Controls.Add(this.label2);
            this.groupBoxMaster.Controls.Add(this.textBoxIPMaster);
            this.groupBoxMaster.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBoxMaster.Location = new System.Drawing.Point(191, 297);
            this.groupBoxMaster.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxMaster.Name = "groupBoxMaster";
            this.groupBoxMaster.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxMaster.Size = new System.Drawing.Size(161, 56);
            this.groupBoxMaster.TabIndex = 31;
            this.groupBoxMaster.TabStop = false;
            this.groupBoxMaster.Text = "Master Configuration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "IP";
            // 
            // textBoxIPMaster
            // 
            this.textBoxIPMaster.Location = new System.Drawing.Point(62, 29);
            this.textBoxIPMaster.Name = "textBoxIPMaster";
            this.textBoxIPMaster.Size = new System.Drawing.Size(81, 20);
            this.textBoxIPMaster.TabIndex = 7;
            // 
            // checkBoxWebFront
            // 
            this.checkBoxWebFront.AutoSize = true;
            this.checkBoxWebFront.Checked = true;
            this.checkBoxWebFront.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWebFront.Enabled = false;
            this.checkBoxWebFront.Location = new System.Drawing.Point(18, 240);
            this.checkBoxWebFront.Name = "checkBoxWebFront";
            this.checkBoxWebFront.Size = new System.Drawing.Size(73, 17);
            this.checkBoxWebFront.TabIndex = 32;
            this.checkBoxWebFront.Text = "WebFront";
            this.checkBoxWebFront.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilaUnica
            // 
            this.checkBoxFilaUnica.AutoSize = true;
            this.checkBoxFilaUnica.Location = new System.Drawing.Point(18, 263);
            this.checkBoxFilaUnica.Name = "checkBoxFilaUnica";
            this.checkBoxFilaUnica.Size = new System.Drawing.Size(70, 17);
            this.checkBoxFilaUnica.TabIndex = 33;
            this.checkBoxFilaUnica.Text = "FilaUnica";
            this.checkBoxFilaUnica.UseVisualStyleBackColor = true;
            this.checkBoxFilaUnica.CheckedChanged += new System.EventHandler(this.CheckBoxFilaUnica_CheckedChanged);
            // 
            // groupBoxFilaUnica
            // 
            this.groupBoxFilaUnica.BackColor = System.Drawing.Color.LightGray;
            this.groupBoxFilaUnica.Controls.Add(this.label7);
            this.groupBoxFilaUnica.Controls.Add(this.textBoxFilaUnica);
            this.groupBoxFilaUnica.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBoxFilaUnica.Location = new System.Drawing.Point(18, 297);
            this.groupBoxFilaUnica.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxFilaUnica.Name = "groupBoxFilaUnica";
            this.groupBoxFilaUnica.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxFilaUnica.Size = new System.Drawing.Size(155, 56);
            this.groupBoxFilaUnica.TabIndex = 32;
            this.groupBoxFilaUnica.TabStop = false;
            this.groupBoxFilaUnica.Text = "Fila unica Configuration";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label7.Location = new System.Drawing.Point(6, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "IP";
            // 
            // textBoxFilaUnica
            // 
            this.textBoxFilaUnica.Location = new System.Drawing.Point(62, 29);
            this.textBoxFilaUnica.Name = "textBoxFilaUnica";
            this.textBoxFilaUnica.Size = new System.Drawing.Size(81, 20);
            this.textBoxFilaUnica.TabIndex = 9;
            // 
            // buttonCONFIGURAR
            // 
            this.buttonCONFIGURAR.AutoSize = true;
            this.buttonCONFIGURAR.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCONFIGURAR.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCONFIGURAR.FlatAppearance.BorderSize = 0;
            this.buttonCONFIGURAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCONFIGURAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCONFIGURAR.Image = global::WindowsFormsApp1.Properties.Resources.ok;
            this.buttonCONFIGURAR.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCONFIGURAR.Location = new System.Drawing.Point(461, 359);
            this.buttonCONFIGURAR.Name = "buttonCONFIGURAR";
            this.buttonCONFIGURAR.Size = new System.Drawing.Size(51, 46);
            this.buttonCONFIGURAR.TabIndex = 26;
            this.buttonCONFIGURAR.UseVisualStyleBackColor = false;
            this.buttonCONFIGURAR.Click += new System.EventHandler(this.ButtonCONFIGURAR_Click);
            // 
            // buttonEXIT
            // 
            this.buttonEXIT.AutoSize = true;
            this.buttonEXIT.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonEXIT.FlatAppearance.BorderSize = 0;
            this.buttonEXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEXIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEXIT.Image = ((System.Drawing.Image)(resources.GetObject("buttonEXIT.Image")));
            this.buttonEXIT.Location = new System.Drawing.Point(515, 359);
            this.buttonEXIT.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEXIT.Name = "buttonEXIT";
            this.buttonEXIT.Size = new System.Drawing.Size(51, 46);
            this.buttonEXIT.TabIndex = 16;
            this.buttonEXIT.UseVisualStyleBackColor = true;
            this.buttonEXIT.Click += new System.EventHandler(this.ButtonEXIT_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(188, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Lanes in Store";
            // 
            // textBoxLanesStore
            // 
            this.textBoxLanesStore.Location = new System.Drawing.Point(284, 85);
            this.textBoxLanesStore.Name = "textBoxLanesStore";
            this.textBoxLanesStore.Size = new System.Drawing.Size(37, 20);
            this.textBoxLanesStore.TabIndex = 39;
            // 
            // textBoxIpFirstLane
            // 
            this.textBoxIpFirstLane.Location = new System.Drawing.Point(284, 110);
            this.textBoxIpFirstLane.Name = "textBoxIpFirstLane";
            this.textBoxIpFirstLane.Size = new System.Drawing.Size(81, 20);
            this.textBoxIpFirstLane.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(188, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "IP First Lane";
            // 
            // groupBoxHWType
            // 
            this.groupBoxHWType.Controls.Add(this.ss90);
            this.groupBoxHWType.Controls.Add(this.cashLess);
            this.groupBoxHWType.Controls.Add(this.cash);
            this.groupBoxHWType.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxHWType.Location = new System.Drawing.Point(9, 99);
            this.groupBoxHWType.Name = "groupBoxHWType";
            this.groupBoxHWType.Size = new System.Drawing.Size(173, 100);
            this.groupBoxHWType.TabIndex = 42;
            this.groupBoxHWType.TabStop = false;
            this.groupBoxHWType.Text = "HWT ype";
            // 
            // ss90
            // 
            this.ss90.AutoSize = true;
            this.ss90.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ss90.Location = new System.Drawing.Point(9, 78);
            this.ss90.Name = "ss90";
            this.ss90.Size = new System.Drawing.Size(51, 17);
            this.ss90.TabIndex = 45;
            this.ss90.TabStop = true;
            this.ss90.Text = "SS90";
            this.ss90.UseVisualStyleBackColor = true;
            // 
            // cashLess
            // 
            this.cashLess.AutoSize = true;
            this.cashLess.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cashLess.Location = new System.Drawing.Point(9, 53);
            this.cashLess.Name = "cashLess";
            this.cashLess.Size = new System.Drawing.Size(67, 17);
            this.cashLess.TabIndex = 44;
            this.cashLess.TabStop = true;
            this.cashLess.Text = "Cashless";
            this.cashLess.UseVisualStyleBackColor = true;
            // 
            // cash
            // 
            this.cash.AutoSize = true;
            this.cash.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cash.Location = new System.Drawing.Point(9, 28);
            this.cash.Name = "cash";
            this.cash.Size = new System.Drawing.Size(49, 17);
            this.cash.TabIndex = 43;
            this.cash.TabStop = true;
            this.cash.Text = "Cash";
            this.cash.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 414);
            this.Controls.Add(this.groupBoxHWType);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxIpFirstLane);
            this.Controls.Add(this.textBoxLanesStore);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSTORE);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxSCO);
            this.Controls.Add(this.checkBoxMaster);
            this.Controls.Add(this.checkBoxFilaUnica);
            this.Controls.Add(this.checkBoxWebFront);
            this.Controls.Add(this.groupBoxFilaUnica);
            this.Controls.Add(this.groupBoxMaster);
            this.Controls.Add(this.groupBoxLane);
            this.Controls.Add(this.textBoxHOSTNAME);
            this.Controls.Add(this.buttonACERCA);
            this.Controls.Add(this.buttonCONFIGURAR);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBoxNCR);
            this.Controls.Add(this.buttonEXIT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(649, 469);
            this.MinimumSize = new System.Drawing.Size(649, 457);
            this.Name = "Form1";
            this.Text = "Configurador SCO";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNCR)).EndInit();
            this.groupBoxLane.ResumeLayout(false);
            this.groupBoxLane.PerformLayout();
            this.groupBoxMaster.ResumeLayout(false);
            this.groupBoxMaster.PerformLayout();
            this.groupBoxFilaUnica.ResumeLayout(false);
            this.groupBoxFilaUnica.PerformLayout();
            this.groupBoxHWType.ResumeLayout(false);
            this.groupBoxHWType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.PictureBox pictureBoxNCR;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSTORE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxSCO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxHOSTNAME;
        private System.Windows.Forms.GroupBox groupBoxLane;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNETMASK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxGATEWAY;
        private System.Windows.Forms.GroupBox groupBoxMaster;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIPMaster;
        private System.Windows.Forms.GroupBox groupBoxFilaUnica;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxFilaUnica;
        private System.Windows.Forms.CheckBox checkBoxMaster;
        private System.Windows.Forms.CheckBox checkBoxWebFront;
        private System.Windows.Forms.CheckBox checkBoxFilaUnica;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Button buttonACERCA;
        private System.Windows.Forms.Button buttonCONFIGURAR;
        private System.Windows.Forms.Button buttonEXIT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxLanesStore;
        private System.Windows.Forms.TextBox textBoxIpFirstLane;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBoxHWType;
        private System.Windows.Forms.RadioButton ss90;
        private System.Windows.Forms.RadioButton cashLess;
        private System.Windows.Forms.RadioButton cash;
    }
}

