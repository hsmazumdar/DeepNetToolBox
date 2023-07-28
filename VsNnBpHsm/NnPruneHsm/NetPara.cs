using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using VnnBpLib;

namespace VnnBp
{
    public partial class NetPara : Form
    {
        //*****************************************************
        public VnnBpLib.VnnBpProj proj;
        public VnnBpDemo demo;
        public string netConfigStr = "";
        public string netDetail = "";
        public int netNo = -1;
        //*****************************************************
        public NetPara()
        {
            InitializeComponent();
            connTypeCoboBx.SelectedIndex = 1;
            
        }
        //*****************************************************
        private void btnExit_Click(object sender, EventArgs e)
        {
            netConfigStr = "";
            this.Close();
        }
        //*****************************************************
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string name = netNameTxBx.Text;
            string conTyp = connTypeCoboBx.SelectedItem.ToString();
            netConfigStr = name + "," + txBxInNu.Text + ',' + txBxOutNu.Text + ',' + conTyp + ',' + txBxHdnNu.Text;
            string[] lns = new string[6];
            lns[0] = netNameTxBx.Text;
            lns[1] = txBxInNu.Text;
            lns[2] = txBxHdnNu.Text;
            lns[3] = txBxOutNu.Text;
            lns[4] = connTypeCoboBx.SelectedIndex.ToString();
            lns[5] = rtbxDetails.Text;
            netDetail = rtbxDetails.Text; 
            File.WriteAllLines("NetPara.txt", lns);
            this.Close();
        }
        //*****************************************************
        private void NetPara_Shown(object sender, EventArgs e)
        {
            if (File.Exists("NetPara.txt"))
            {
                string[] lns = File.ReadAllLines("NetPara.txt");
                netNameTxBx.Text = lns[0];
                txBxInNu.Text = lns[1];
                txBxHdnNu.Text = lns[2];
                txBxOutNu.Text = lns[3];
                int no = int.Parse(lns[4]);
                connTypeCoboBx.SelectedIndex = no;
            }
            netNo = 0;
            btnLoadNet.Focus();
        }
        //*****************************************************
        private void btnLoadNet_Click(object sender, EventArgs e)
        {
            string netFlnm = "";
            if (File.Exists(@"netPath.txt"))
            {
                netFlnm = File.ReadAllText(@"netPath.txt");
            }
            openFileDialog1.InitialDirectory = netFlnm;
            openFileDialog1.FileName = netFlnm;
            openFileDialog1.Title = "Select Net Files(*.net)";
            openFileDialog1.Filter = "Data (*.net)|*.net|" + "All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            netFlnm = openFileDialog1.FileName;
            File.WriteAllText(@"netPath.txt", netFlnm);
            VnnBpLib.VnnBpLodSav ldsv = new VnnBpLib.VnnBpLodSav();
            ldsv.LoadProjData(netFlnm);
            proj = (VnnBpLib.VnnBpProj)ldsv.proj;
            demo.train = new TrainThisNet();
            demo.train.proj = proj;
            demo.train.demo = demo;
            int[] lyr = proj.vnnnet[0].nuLayers;
            string lyrstr = "";
            for (int i = 1; i < lyr.Length-1; i++)
            {
                lyrstr += lyr[i].ToString() + ",";    
            }
            lyrstr = lyrstr.TrimEnd(',');
            netNameTxBx.Text = proj.vnnnet[0].netName;
            txBxInNu.Text = proj.vnnnet[0].maxInputs.ToString();
            txBxHdnNu.Text = lyrstr;
            txBxOutNu.Text = proj.vnnnet[0].maxOutputs.ToString();
            connTypeCoboBx.SelectedIndex = proj.vnnnet[0].connTypeNo;
            rtbxDetails.Text = proj.vnnnet[0].netDetail;
            demo.train.InitializeNeuronsPosition2();
            demo.train.PlotNetAll();
            demo.pbxNetVw.Image = demo.train.pictureBox2.Image;
            btnConfirm.Focus();
        }
        //*****************************************************
        private void btnSaveNet_Click(object sender, EventArgs e)
        {
            if (proj.vnnnet == null)
            {
                string name = netNameTxBx.Text;
                string conTyp = connTypeCoboBx.SelectedItem.ToString();
                netConfigStr = name + "," + txBxInNu.Text + ',' + txBxOutNu.Text + ',' + conTyp + ',' + txBxHdnNu.Text;
                netDetail = rtbxDetails.Text;
                bool r1 = proj.AddNet(netConfigStr, netDetail);
                if (r1 == false)
                {
                    MessageBox.Show(proj.errMsg);
                    return;
                }
            }
            string dataFlnm = "";
            if (File.Exists(@"netPath.txt"))
            {
                dataFlnm = File.ReadAllText(@"netPath.txt");
            }
            saveFileDialog1.Title = "Enter Save Net File Name(*.net)";
            saveFileDialog1.InitialDirectory = dataFlnm;
            saveFileDialog1.FileName = dataFlnm;
            saveFileDialog1.Filter = "Data (*.net)|*.net|" + "All files (*.*)|*.*";
            DialogResult r = saveFileDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.Cancel)
                return;
            demo.netFlnm = saveFileDialog1.FileName;
            File.WriteAllText(@"netPath.txt", demo.netFlnm);

            VnnBpLib.VnnBpLodSav ldsv = new VnnBpLib.VnnBpLodSav(proj);
            ldsv.proj=proj;
            ldsv.SaveProjFile(demo.netFlnm);
            string buf = File.ReadAllText(demo.netFlnm);//test only
        }
        //*****************************************************
    }
}