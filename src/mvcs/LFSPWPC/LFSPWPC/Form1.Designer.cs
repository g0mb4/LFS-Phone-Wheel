namespace LFSPWPC
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
            this.txbIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbClient = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbPosX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chbTest = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbGear = new System.Windows.Forms.TextBox();
            this.rbHBrake = new System.Windows.Forms.RadioButton();
            this.rbBrake = new System.Windows.Forms.RadioButton();
            this.rbGas = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbAcc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbMouse = new System.Windows.Forms.TextBox();
            this.tbSens = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.txbSens = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbNoise = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSens)).BeginInit();
            this.SuspendLayout();
            // 
            // txbIP
            // 
            this.txbIP.Enabled = false;
            this.txbIP.Location = new System.Drawing.Point(16, 27);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(169, 20);
            this.txbIP.TabIndex = 0;
            this.txbIP.Text = "- -";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server IP:";
            // 
            // txbClient
            // 
            this.txbClient.Enabled = false;
            this.txbClient.Location = new System.Drawing.Point(253, 26);
            this.txbClient.Name = "txbClient";
            this.txbClient.Size = new System.Drawing.Size(159, 20);
            this.txbClient.TabIndex = 3;
            this.txbClient.Text = "- -";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Client:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txbPosX);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chbTest);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbGear);
            this.groupBox1.Controls.Add(this.rbHBrake);
            this.groupBox1.Controls.Add(this.rbBrake);
            this.groupBox1.Controls.Add(this.rbGas);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txbAcc);
            this.groupBox1.Location = new System.Drawing.Point(0, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 181);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Pos X:";
            // 
            // txbPosX
            // 
            this.txbPosX.Enabled = false;
            this.txbPosX.Location = new System.Drawing.Point(100, 85);
            this.txbPosX.Name = "txbPosX";
            this.txbPosX.Size = new System.Drawing.Size(42, 20);
            this.txbPosX.TabIndex = 26;
            this.txbPosX.Text = "--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "==>";
            // 
            // chbTest
            // 
            this.chbTest.AutoSize = true;
            this.chbTest.Location = new System.Drawing.Point(16, 19);
            this.chbTest.Name = "chbTest";
            this.chbTest.Size = new System.Drawing.Size(47, 17);
            this.chbTest.TabIndex = 8;
            this.chbTest.Text = "Test";
            this.chbTest.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Gear:";
            // 
            // txbGear
            // 
            this.txbGear.Enabled = false;
            this.txbGear.Location = new System.Drawing.Point(345, 47);
            this.txbGear.Name = "txbGear";
            this.txbGear.Size = new System.Drawing.Size(67, 20);
            this.txbGear.TabIndex = 20;
            this.txbGear.Text = "N";
            // 
            // rbHBrake
            // 
            this.rbHBrake.AutoSize = true;
            this.rbHBrake.Enabled = false;
            this.rbHBrake.Location = new System.Drawing.Point(253, 70);
            this.rbHBrake.Name = "rbHBrake";
            this.rbHBrake.Size = new System.Drawing.Size(82, 17);
            this.rbHBrake.TabIndex = 19;
            this.rbHBrake.TabStop = true;
            this.rbHBrake.Text = "Hand Brake";
            this.rbHBrake.UseVisualStyleBackColor = true;
            // 
            // rbBrake
            // 
            this.rbBrake.AutoSize = true;
            this.rbBrake.Enabled = false;
            this.rbBrake.Location = new System.Drawing.Point(253, 47);
            this.rbBrake.Name = "rbBrake";
            this.rbBrake.Size = new System.Drawing.Size(53, 17);
            this.rbBrake.TabIndex = 18;
            this.rbBrake.TabStop = true;
            this.rbBrake.Text = "Brake";
            this.rbBrake.UseVisualStyleBackColor = true;
            // 
            // rbGas
            // 
            this.rbGas.AutoSize = true;
            this.rbGas.Enabled = false;
            this.rbGas.Location = new System.Drawing.Point(253, 26);
            this.rbGas.Name = "rbGas";
            this.rbGas.Size = new System.Drawing.Size(44, 17);
            this.rbGas.TabIndex = 17;
            this.rbGas.TabStop = true;
            this.rbGas.Text = "Gas";
            this.rbGas.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 50);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Recieved data:";
            // 
            // txbAcc
            // 
            this.txbAcc.Enabled = false;
            this.txbAcc.Location = new System.Drawing.Point(17, 59);
            this.txbAcc.Name = "txbAcc";
            this.txbAcc.Size = new System.Drawing.Size(168, 20);
            this.txbAcc.TabIndex = 14;
            this.txbAcc.Text = "- -";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(233, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Mouse:";
            // 
            // txbMouse
            // 
            this.txbMouse.Enabled = false;
            this.txbMouse.Location = new System.Drawing.Point(274, 59);
            this.txbMouse.Name = "txbMouse";
            this.txbMouse.Size = new System.Drawing.Size(42, 20);
            this.txbMouse.TabIndex = 27;
            this.txbMouse.Text = "--";
            // 
            // tbSens
            // 
            this.tbSens.Location = new System.Drawing.Point(12, 81);
            this.tbSens.Maximum = 200;
            this.tbSens.Minimum = 20;
            this.tbSens.Name = "tbSens";
            this.tbSens.Size = new System.Drawing.Size(265, 45);
            this.tbSens.TabIndex = 9;
            this.tbSens.Value = 20;
            this.tbSens.Scroll += new System.EventHandler(this.tbSens_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Sensitivity:";
            // 
            // txbSens
            // 
            this.txbSens.Location = new System.Drawing.Point(274, 85);
            this.txbSens.Name = "txbSens";
            this.txbSens.Size = new System.Drawing.Size(70, 20);
            this.txbSens.TabIndex = 11;
            this.txbSens.TextChanged += new System.EventHandler(this.txbSens_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(292, 363);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "[g0mb4] - [2012] - [v1.1]";
            // 
            // txbNoise
            // 
            this.txbNoise.Location = new System.Drawing.Point(274, 119);
            this.txbNoise.Name = "txbNoise";
            this.txbNoise.Size = new System.Drawing.Size(70, 20);
            this.txbNoise.TabIndex = 30;
            this.txbNoise.TextChanged += new System.EventHandler(this.txbNoise_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(186, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Maximum noise:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 385);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txbNoise);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txbSens);
            this.Controls.Add(this.txbMouse);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbSens);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "LFSPWPC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbGear;
        private System.Windows.Forms.RadioButton rbHBrake;
        private System.Windows.Forms.RadioButton rbBrake;
        private System.Windows.Forms.RadioButton rbGas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbAcc;
        private System.Windows.Forms.CheckBox chbTest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbMouse;
        private System.Windows.Forms.TextBox txbPosX;
        private System.Windows.Forms.TrackBar tbSens;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbSens;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbNoise;
        private System.Windows.Forms.Label label10;
    }
}

