namespace VnnBp
{
    partial class VnnBpDemo
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFileAddNet = new System.Windows.Forms.Button();
            this.btnTrainNet = new System.Windows.Forms.Button();
            this.btnNewData = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnSaveNet = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnLoadNet = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pbxNetVw = new System.Windows.Forms.PictureBox();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNetVw)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(431, 272);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(43, 23);
            this.btnExit.TabIndex = 82;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFileAddNet
            // 
            this.btnFileAddNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFileAddNet.Location = new System.Drawing.Point(6, 272);
            this.btnFileAddNet.Name = "btnFileAddNet";
            this.btnFileAddNet.Size = new System.Drawing.Size(67, 23);
            this.btnFileAddNet.TabIndex = 83;
            this.btnFileAddNet.Text = "Sel Net";
            this.btnFileAddNet.UseVisualStyleBackColor = true;
            this.btnFileAddNet.Click += new System.EventHandler(this.btnFileAddNet_Click);
            // 
            // btnTrainNet
            // 
            this.btnTrainNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTrainNet.Location = new System.Drawing.Point(140, 272);
            this.btnTrainNet.Name = "btnTrainNet";
            this.btnTrainNet.Size = new System.Drawing.Size(60, 23);
            this.btnTrainNet.TabIndex = 84;
            this.btnTrainNet.Text = "Train Net";
            this.btnTrainNet.UseVisualStyleBackColor = true;
            this.btnTrainNet.Click += new System.EventHandler(this.btnTrainNet_Click);
            // 
            // btnNewData
            // 
            this.btnNewData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewData.Location = new System.Drawing.Point(73, 272);
            this.btnNewData.Name = "btnNewData";
            this.btnNewData.Size = new System.Drawing.Size(67, 23);
            this.btnNewData.TabIndex = 85;
            this.btnNewData.Text = "Sel Data";
            this.btnNewData.UseVisualStyleBackColor = true;
            this.btnNewData.Click += new System.EventHandler(this.btnNewData_Click);
            // 
            // btnSaveData
            // 
            this.btnSaveData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveData.Location = new System.Drawing.Point(8, 249);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(67, 23);
            this.btnSaveData.TabIndex = 87;
            this.btnSaveData.Text = "Save Data";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Visible = false;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnSaveNet
            // 
            this.btnSaveNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveNet.Location = new System.Drawing.Point(142, 249);
            this.btnSaveNet.Name = "btnSaveNet";
            this.btnSaveNet.Size = new System.Drawing.Size(67, 23);
            this.btnSaveNet.TabIndex = 86;
            this.btnSaveNet.Text = "Save Net";
            this.btnSaveNet.UseVisualStyleBackColor = true;
            this.btnSaveNet.Visible = false;
            this.btnSaveNet.Click += new System.EventHandler(this.btnSaveNet_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadData.Location = new System.Drawing.Point(75, 249);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(67, 23);
            this.btnLoadData.TabIndex = 89;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Visible = false;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnLoadNet
            // 
            this.btnLoadNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadNet.Location = new System.Drawing.Point(209, 249);
            this.btnLoadNet.Name = "btnLoadNet";
            this.btnLoadNet.Size = new System.Drawing.Size(67, 23);
            this.btnLoadNet.TabIndex = 88;
            this.btnLoadNet.Text = "Load Net";
            this.btnLoadNet.UseVisualStyleBackColor = true;
            this.btnLoadNet.Visible = false;
            this.btnLoadNet.Click += new System.EventHandler(this.btnLoadNet_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pbxNetVw
            // 
            this.pbxNetVw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxNetVw.Location = new System.Drawing.Point(6, 2);
            this.pbxNetVw.Name = "pbxNetVw";
            this.pbxNetVw.Size = new System.Drawing.Size(469, 270);
            this.pbxNetVw.TabIndex = 106;
            this.pbxNetVw.TabStop = false;
            this.pbxNetVw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxNetVw_MouseDown);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Location = new System.Drawing.Point(388, 272);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(43, 23);
            this.btnHelp.TabIndex = 107;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // VnnBpDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 300);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.pbxNetVw);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.btnLoadNet);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.btnSaveNet);
            this.Controls.Add(this.btnNewData);
            this.Controls.Add(this.btnTrainNet);
            this.Controls.Add(this.btnFileAddNet);
            this.Controls.Add(this.btnExit);
            this.Name = "VnnBpDemo";
            this.Text = "Multi Layer Neural Net Optimization- HSM";
            this.Shown += new System.EventHandler(this.VnnBpDemo_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxNetVw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFileAddNet;
        private System.Windows.Forms.Button btnTrainNet;
        private System.Windows.Forms.Button btnNewData;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnSaveNet;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnLoadNet;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.PictureBox pbxNetVw;
        private System.Windows.Forms.Button btnHelp;
    }
}

