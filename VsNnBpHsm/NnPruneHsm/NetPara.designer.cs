namespace VnnBp
{
    partial class NetPara
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
            //this.Hide();//HSM 03/02/2017
            //return;//HSM 03/02/2017
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
            this.connTypeCoboBx = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.netNameTxBx = new System.Windows.Forms.TextBox();
            this.txBxInNu = new System.Windows.Forms.TextBox();
            this.txBxHdnNu = new System.Windows.Forms.TextBox();
            this.txBxOutNu = new System.Windows.Forms.TextBox();
            this.hdrInNu = new System.Windows.Forms.TextBox();
            this.hdrHdnNu = new System.Windows.Forms.TextBox();
            this.hdrOutNu = new System.Windows.Forms.TextBox();
            this.hdrNetName = new System.Windows.Forms.TextBox();
            this.hdrConnType = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rtbxDetails = new System.Windows.Forms.RichTextBox();
            this.btnLoadNet = new System.Windows.Forms.Button();
            this.btnSaveNet = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // connTypeCoboBx
            // 
            this.connTypeCoboBx.FormattingEnabled = true;
            this.connTypeCoboBx.Items.AddRange(new object[] {
            "No Conn",
            "In Layer Conn",
            "In2 Layer Conn",
            "All Layer Conn",
            "Fully Conn",
            "Partly Conn"});
            this.connTypeCoboBx.Location = new System.Drawing.Point(135, 146);
            this.connTypeCoboBx.Name = "connTypeCoboBx";
            this.connTypeCoboBx.Size = new System.Drawing.Size(107, 21);
            this.connTypeCoboBx.TabIndex = 30;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(245, 179);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(65, 23);
            this.btnConfirm.TabIndex = 29;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(245, 92);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(65, 23);
            this.btnExit.TabIndex = 33;
            this.btnExit.Text = "Cancle";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // netNameTxBx
            // 
            this.netNameTxBx.Location = new System.Drawing.Point(135, 16);
            this.netNameTxBx.Name = "netNameTxBx";
            this.netNameTxBx.Size = new System.Drawing.Size(112, 20);
            this.netNameTxBx.TabIndex = 34;
            this.netNameTxBx.Text = "VNetName";
            // 
            // txBxInNu
            // 
            this.txBxInNu.Location = new System.Drawing.Point(135, 50);
            this.txBxInNu.Name = "txBxInNu";
            this.txBxInNu.Size = new System.Drawing.Size(28, 20);
            this.txBxInNu.TabIndex = 39;
            this.txBxInNu.Text = "1";
            // 
            // txBxHdnNu
            // 
            this.txBxHdnNu.Location = new System.Drawing.Point(135, 83);
            this.txBxHdnNu.Name = "txBxHdnNu";
            this.txBxHdnNu.Size = new System.Drawing.Size(104, 20);
            this.txBxHdnNu.TabIndex = 41;
            this.txBxHdnNu.Text = "0";
            // 
            // txBxOutNu
            // 
            this.txBxOutNu.Location = new System.Drawing.Point(135, 115);
            this.txBxOutNu.Name = "txBxOutNu";
            this.txBxOutNu.Size = new System.Drawing.Size(28, 20);
            this.txBxOutNu.TabIndex = 43;
            this.txBxOutNu.Text = "1";
            // 
            // hdrInNu
            // 
            this.hdrInNu.BackColor = System.Drawing.SystemColors.Menu;
            this.hdrInNu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hdrInNu.Location = new System.Drawing.Point(53, 49);
            this.hdrInNu.Multiline = true;
            this.hdrInNu.Name = "hdrInNu";
            this.hdrInNu.Size = new System.Drawing.Size(76, 30);
            this.hdrInNu.TabIndex = 44;
            this.hdrInNu.Text = "Input Neurons:\r\n   (1-100)";
            this.hdrInNu.WordWrap = false;
            // 
            // hdrHdnNu
            // 
            this.hdrHdnNu.BackColor = System.Drawing.SystemColors.Menu;
            this.hdrHdnNu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hdrHdnNu.Location = new System.Drawing.Point(12, 83);
            this.hdrHdnNu.Multiline = true;
            this.hdrHdnNu.Name = "hdrHdnNu";
            this.hdrHdnNu.Size = new System.Drawing.Size(117, 30);
            this.hdrHdnNu.TabIndex = 45;
            this.hdrHdnNu.Text = "Hidden Layers Neurons:\r\nExample: 4,3,5\r\n";
            this.hdrHdnNu.WordWrap = false;
            // 
            // hdrOutNu
            // 
            this.hdrOutNu.BackColor = System.Drawing.SystemColors.Menu;
            this.hdrOutNu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hdrOutNu.Location = new System.Drawing.Point(48, 114);
            this.hdrOutNu.Multiline = true;
            this.hdrOutNu.Name = "hdrOutNu";
            this.hdrOutNu.Size = new System.Drawing.Size(81, 26);
            this.hdrOutNu.TabIndex = 46;
            this.hdrOutNu.Text = "Output Neurons:\r\n   (1-100)";
            this.hdrOutNu.WordWrap = false;
            // 
            // hdrNetName
            // 
            this.hdrNetName.BackColor = System.Drawing.SystemColors.Menu;
            this.hdrNetName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hdrNetName.Location = new System.Drawing.Point(53, 15);
            this.hdrNetName.Multiline = true;
            this.hdrNetName.Name = "hdrNetName";
            this.hdrNetName.Size = new System.Drawing.Size(76, 30);
            this.hdrNetName.TabIndex = 47;
            this.hdrNetName.Text = "Net Name:\r\n(One Word)";
            this.hdrNetName.WordWrap = false;
            // 
            // hdrConnType
            // 
            this.hdrConnType.BackColor = System.Drawing.SystemColors.Menu;
            this.hdrConnType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hdrConnType.Location = new System.Drawing.Point(43, 146);
            this.hdrConnType.Multiline = true;
            this.hdrConnType.Name = "hdrConnType";
            this.hdrConnType.Size = new System.Drawing.Size(86, 25);
            this.hdrConnType.TabIndex = 48;
            this.hdrConnType.Text = "Connection Type:";
            this.hdrConnType.WordWrap = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(2, 170);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 18);
            this.textBox1.TabIndex = 49;
            this.textBox1.Text = "Net Details:";
            this.textBox1.WordWrap = false;
            // 
            // rtbxDetails
            // 
            this.rtbxDetails.Location = new System.Drawing.Point(63, 170);
            this.rtbxDetails.Name = "rtbxDetails";
            this.rtbxDetails.Size = new System.Drawing.Size(179, 37);
            this.rtbxDetails.TabIndex = 50;
            this.rtbxDetails.Text = "Enter Net  Details here";
            // 
            // btnLoadNet
            // 
            this.btnLoadNet.Location = new System.Drawing.Point(245, 150);
            this.btnLoadNet.Name = "btnLoadNet";
            this.btnLoadNet.Size = new System.Drawing.Size(65, 23);
            this.btnLoadNet.TabIndex = 90;
            this.btnLoadNet.Text = "Load Net";
            this.btnLoadNet.UseVisualStyleBackColor = true;
            this.btnLoadNet.Click += new System.EventHandler(this.btnLoadNet_Click);
            // 
            // btnSaveNet
            // 
            this.btnSaveNet.Location = new System.Drawing.Point(245, 121);
            this.btnSaveNet.Name = "btnSaveNet";
            this.btnSaveNet.Size = new System.Drawing.Size(65, 23);
            this.btnSaveNet.TabIndex = 89;
            this.btnSaveNet.Text = "Save Net";
            this.btnSaveNet.UseVisualStyleBackColor = true;
            this.btnSaveNet.Click += new System.EventHandler(this.btnSaveNet_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // NetPara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 207);
            this.Controls.Add(this.btnLoadNet);
            this.Controls.Add(this.btnSaveNet);
            this.Controls.Add(this.rtbxDetails);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.hdrConnType);
            this.Controls.Add(this.hdrNetName);
            this.Controls.Add(this.hdrOutNu);
            this.Controls.Add(this.hdrHdnNu);
            this.Controls.Add(this.hdrInNu);
            this.Controls.Add(this.txBxOutNu);
            this.Controls.Add(this.txBxHdnNu);
            this.Controls.Add(this.txBxInNu);
            this.Controls.Add(this.netNameTxBx);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.connTypeCoboBx);
            this.Controls.Add(this.btnConfirm);
            this.Name = "NetPara";
            this.Text = "Neural Net Basic Parameters";
            this.Shown += new System.EventHandler(this.NetPara_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox connTypeCoboBx;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox netNameTxBx;
        private System.Windows.Forms.TextBox txBxInNu;
        private System.Windows.Forms.TextBox txBxHdnNu;
        private System.Windows.Forms.TextBox txBxOutNu;
        private System.Windows.Forms.TextBox hdrInNu;
        private System.Windows.Forms.TextBox hdrHdnNu;
        private System.Windows.Forms.TextBox hdrOutNu;
        private System.Windows.Forms.TextBox hdrNetName;
        private System.Windows.Forms.TextBox hdrConnType;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox rtbxDetails;
        private System.Windows.Forms.Button btnLoadNet;
        private System.Windows.Forms.Button btnSaveNet;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}