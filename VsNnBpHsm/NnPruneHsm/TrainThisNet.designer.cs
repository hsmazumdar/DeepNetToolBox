namespace VnnBp
{
    partial class TrainThisNet
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
            this.components = new System.ComponentModel.Container();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblMinErr = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblErr = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnEta = new System.Windows.Forms.Button();
            this.txbxEta = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblNetNm = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblNetNum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTrainStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnRand = new System.Windows.Forms.Button();
            this.lblIntErr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrune = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbxPrun = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblConMx = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblNuMx = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsComboNu = new System.Windows.Forms.ToolStripComboBox();
            this.tstxbxNuTyp = new System.Windows.Forms.ToolStripTextBox();
            this.tsComboNuFun = new System.Windows.Forms.ToolStripComboBox();
            this.btnOptimizeNeuronPosition = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(240, 275);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(43, 20);
            this.btnExit.TabIndex = 81;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblMinErr
            // 
            this.lblMinErr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMinErr.AutoSize = true;
            this.lblMinErr.Location = new System.Drawing.Point(149, 236);
            this.lblMinErr.Name = "lblMinErr";
            this.lblMinErr.Size = new System.Drawing.Size(30, 13);
            this.lblMinErr.TabIndex = 78;
            this.lblMinErr.Text = "ERR";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(96, 236);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 77;
            this.label13.Text = "MxAccu%: ";
            // 
            // lblErr
            // 
            this.lblErr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErr.AutoSize = true;
            this.lblErr.Location = new System.Drawing.Point(40, 236);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(30, 13);
            this.lblErr.TabIndex = 76;
            this.lblErr.Text = "ERR";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 236);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 75;
            this.label12.Text = "Accu%: ";
            // 
            // btnEta
            // 
            this.btnEta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEta.Location = new System.Drawing.Point(208, 276);
            this.btnEta.Name = "btnEta";
            this.btnEta.Size = new System.Drawing.Size(30, 20);
            this.btnEta.TabIndex = 74;
            this.btnEta.Text = "<=";
            this.btnEta.UseVisualStyleBackColor = true;
            this.btnEta.Click += new System.EventHandler(this.btnEta_Click);
            // 
            // txbxEta
            // 
            this.txbxEta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txbxEta.Location = new System.Drawing.Point(165, 276);
            this.txbxEta.Margin = new System.Windows.Forms.Padding(2);
            this.txbxEta.Name = "txbxEta";
            this.txbxEta.Size = new System.Drawing.Size(42, 20);
            this.txbxEta.TabIndex = 73;
            this.txbxEta.Text = "0.003";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(141, 279);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 72;
            this.label11.Text = "Eta: ";
            // 
            // lblNetNm
            // 
            this.lblNetNm.AutoSize = true;
            this.lblNetNm.Location = new System.Drawing.Point(182, 9);
            this.lblNetNm.Name = "lblNetNm";
            this.lblNetNm.Size = new System.Drawing.Size(47, 13);
            this.lblNetNm.TabIndex = 69;
            this.lblNetNm.Text = "Name....";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(134, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 68;
            this.label9.Text = "NetNm: ";
            // 
            // lblNetNum
            // 
            this.lblNetNum.AutoSize = true;
            this.lblNetNum.Location = new System.Drawing.Point(60, 9);
            this.lblNetNum.Name = "lblNetNum";
            this.lblNetNum.Size = new System.Drawing.Size(60, 13);
            this.lblNetNum.TabIndex = 83;
            this.lblNetNum.Text = "Net SNo....";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "NetNum: ";
            // 
            // btnTrainStop
            // 
            this.btnTrainStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTrainStop.Location = new System.Drawing.Point(41, 276);
            this.btnTrainStop.Name = "btnTrainStop";
            this.btnTrainStop.Size = new System.Drawing.Size(42, 20);
            this.btnTrainStop.TabIndex = 84;
            this.btnTrainStop.Text = "Train";
            this.btnTrainStop.UseVisualStyleBackColor = true;
            this.btnTrainStop.Click += new System.EventHandler(this.btnTrainStop_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnRand
            // 
            this.btnRand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRand.Location = new System.Drawing.Point(0, 276);
            this.btnRand.Name = "btnRand";
            this.btnRand.Size = new System.Drawing.Size(42, 20);
            this.btnRand.TabIndex = 85;
            this.btnRand.Text = "Rand";
            this.btnRand.UseVisualStyleBackColor = true;
            this.btnRand.Click += new System.EventHandler(this.btnRand_Click);
            // 
            // lblIntErr
            // 
            this.lblIntErr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIntErr.AutoSize = true;
            this.lblIntErr.Location = new System.Drawing.Point(149, 252);
            this.lblIntErr.Name = "lblIntErr";
            this.lblIntErr.Size = new System.Drawing.Size(30, 13);
            this.lblIntErr.TabIndex = 87;
            this.lblIntErr.Text = "ERR";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 86;
            this.label3.Text = "Int.Error: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Location = new System.Drawing.Point(3, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(278, 185);
            this.pictureBox1.TabIndex = 88;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(38, 252);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(25, 13);
            this.lblCount.TabIndex = 90;
            this.lblCount.Text = "000";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 89;
            this.label4.Text = "Count: ";
            // 
            // btnPrune
            // 
            this.btnPrune.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrune.Location = new System.Drawing.Point(189, 252);
            this.btnPrune.Name = "btnPrune";
            this.btnPrune.Size = new System.Drawing.Size(50, 20);
            this.btnPrune.TabIndex = 91;
            this.btnPrune.Text = "Prune*";
            this.btnPrune.UseVisualStyleBackColor = true;
            this.btnPrune.Click += new System.EventHandler(this.btnPrune_Click);
            this.btnPrune.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPrune_MouseDown);
            // 
            // btnImage
            // 
            this.btnImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImage.Location = new System.Drawing.Point(189, 232);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(50, 20);
            this.btnImage.TabIndex = 92;
            this.btnImage.Text = "Image";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTest.Location = new System.Drawing.Point(82, 276);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(42, 20);
            this.btnTest.TabIndex = 104;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.txbxPrun);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblConMx);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.lblNuMx);
            this.panel2.Location = new System.Drawing.Point(6, 212);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 18);
            this.panel2.TabIndex = 104;
            // 
            // txbxPrun
            // 
            this.txbxPrun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txbxPrun.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbxPrun.Location = new System.Drawing.Point(230, 0);
            this.txbxPrun.Name = "txbxPrun";
            this.txbxPrun.Size = new System.Drawing.Size(41, 18);
            this.txbxPrun.TabIndex = 102;
            this.txbxPrun.Text = "1.1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 95;
            this.label1.Text = "Con:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblConMx
            // 
            this.lblConMx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblConMx.AutoSize = true;
            this.lblConMx.Location = new System.Drawing.Point(32, 2);
            this.lblConMx.Name = "lblConMx";
            this.lblConMx.Size = new System.Drawing.Size(10, 13);
            this.lblConMx.TabIndex = 96;
            this.lblConMx.Text = "-";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(190, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 101;
            this.label15.Text = "Prune:";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(70, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 13);
            this.label16.TabIndex = 97;
            this.label16.Text = "Neuron:";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // lblNuMx
            // 
            this.lblNuMx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNuMx.AutoSize = true;
            this.lblNuMx.Location = new System.Drawing.Point(111, 2);
            this.lblNuMx.Name = "lblNuMx";
            this.lblNuMx.Size = new System.Drawing.Size(10, 13);
            this.lblNuMx.TabIndex = 98;
            this.lblNuMx.Text = "-";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Location = new System.Drawing.Point(287, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(372, 261);
            this.pictureBox2.TabIndex = 105;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(287, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 30);
            this.panel1.TabIndex = 106;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsComboNu,
            this.tstxbxNuTyp,
            this.tsComboNuFun});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(372, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsComboNu
            // 
            this.tsComboNu.Name = "tsComboNu";
            this.tsComboNu.Size = new System.Drawing.Size(90, 28);
            this.tsComboNu.SelectedIndexChanged += new System.EventHandler(this.tsComboNu_SelectedIndexChanged);
            this.tsComboNu.Click += new System.EventHandler(this.tsComboNu_Click);
            // 
            // tstxbxNuTyp
            // 
            this.tstxbxNuTyp.Name = "tstxbxNuTyp";
            this.tstxbxNuTyp.Size = new System.Drawing.Size(100, 28);
            // 
            // tsComboNuFun
            // 
            this.tsComboNuFun.Name = "tsComboNuFun";
            this.tsComboNuFun.Size = new System.Drawing.Size(75, 28);
            // 
            // btnOptimizeNeuronPosition
            // 
            this.btnOptimizeNeuronPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOptimizeNeuronPosition.Location = new System.Drawing.Point(240, 252);
            this.btnOptimizeNeuronPosition.Name = "btnOptimizeNeuronPosition";
            this.btnOptimizeNeuronPosition.Size = new System.Drawing.Size(43, 20);
            this.btnOptimizeNeuronPosition.TabIndex = 107;
            this.btnOptimizeNeuronPosition.Text = "Optm";
            this.btnOptimizeNeuronPosition.UseVisualStyleBackColor = true;
            this.btnOptimizeNeuronPosition.Click += new System.EventHandler(this.btnOptimizeNeuronPosition_Click);
            // 
            // TrainThisNet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 300);
            this.Controls.Add(this.btnOptimizeNeuronPosition);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.btnPrune);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblIntErr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRand);
            this.Controls.Add(this.btnTrainStop);
            this.Controls.Add(this.lblNetNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblMinErr);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnEta);
            this.Controls.Add(this.txbxEta);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblNetNm);
            this.Controls.Add(this.label9);
            this.Name = "TrainThisNet";
            this.Text = "TrainNet-";
            this.Shown += new System.EventHandler(this.TrainThisNet_Shown);
            this.LocationChanged += new System.EventHandler(this.TrainThisNet_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblMinErr;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnEta;
        private System.Windows.Forms.TextBox txbxEta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblNetNm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblNetNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTrainStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRand;
        private System.Windows.Forms.Label lblIntErr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrune;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbxPrun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConMx;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblNuMx;
        private System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox tsComboNu;
        private System.Windows.Forms.ToolStripComboBox tsComboNuFun;
        private System.Windows.Forms.ToolStripTextBox tstxbxNuTyp;
        private System.Windows.Forms.Button btnOptimizeNeuronPosition;
    }
}