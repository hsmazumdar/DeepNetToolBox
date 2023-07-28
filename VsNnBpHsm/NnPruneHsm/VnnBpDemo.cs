using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using VnnBpLib;

namespace VnnBp
{
    public partial class VnnBpDemo : Form
    {
        //*********************************************************
        public VnnBpLib.VnnBpProj vnnproj;
        public TrainThisNet train;
        public NetPara netpara;
        public string netFlnm = "";
        //*********************************************************
        public VnnBpDemo()
        {
            InitializeComponent();
            vnnproj = new VnnBpLib.VnnBpProj();
            netpara = new NetPara();
            netpara.demo = this;
            netpara.proj = vnnproj;
            train = new TrainThisNet();
            train.demo = this;
            train.proj = vnnproj;
        }
        //*********************************************************
        private void VnnBpDemo_Shown(object sender, EventArgs e)
        {
            btnFileAddNet.Focus();
        }
        //*********************************************************
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //*********************************************************
        private void btnFileAddNet_Click(object sender, EventArgs e)
        {
            netpara.ShowDialog();
            if (netpara.netConfigStr != "")
            {
                if (vnnproj.vnnnet != null)
                    vnnproj.DeleateNet(0); 
                bool r = vnnproj.AddNet(netpara.netConfigStr, netpara.netDetail);
                if (r == false)
                {
                    MessageBox.Show(vnnproj.errMsg);
                    return;
                }
            }
            train.proj = vnnproj;
            train.InitializeNeuronsPosition2();
            train.PlotNetAll();
            pbxNetVw.Image = train.pictureBox2.Image;
            btnNewData.Focus();
        }
        //*********************************************************
        private void btnTrainNet_Click(object sender, EventArgs e)
        {
            train.Show();
        }
        //*********************************************************
        private void btnNewData_Click(object sender, EventArgs e)
        {
            if (vnnproj == null)
            {
                MessageBox.Show("No Net File Loaded");
                return;
            }
            NewData newdata = new NewData();
            newdata.proj = vnnproj;
            newdata.train = train;
            newdata.Show();
            btnTrainNet.Focus();
        }
        //*********************************************************
        private void btnLoadData_Click(object sender, EventArgs e)//Visibil=False
        {
            if (vnnproj == null)
            {
                MessageBox.Show("No Net File Loaded");
                return;
            }
            NewData newdata = new NewData();
            newdata.proj = vnnproj;
            newdata.train = train;

            string dataFlnm = "";
            if (File.Exists(@"dataPath.txt"))
            {
                dataFlnm = File.ReadAllText(@"dataPath.txt");
            }
            openFileDialog1.InitialDirectory = dataFlnm;
            openFileDialog1.FileName = dataFlnm;
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Select Multiple Data Files(*.txt)";
            openFileDialog1.Filter = "Data (*.txt)|*.txt|" + "All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            dataFlnm = openFileDialog1.FileName;
            File.WriteAllText(@"dataPath.txt", dataFlnm);
            string[] flnms = openFileDialog1.FileNames;
            LoadMultipleDataFiles(flnms);
            //newdata.Show();
        }
        //*********************************************************
        private void LoadMultipleDataFiles(string[] flnms)
        {   // WSN Localization data collected from Python code WsnLocalizer.py
            //flnms contain data in format=>[[x1,y1],[x2,y2],[x3,y3],[x4,y4]]=>[p1,p2,p3,p4]
            //Points(x,y) p1,p2,p3 and p4 are with in transmission range of each other
            ArrayList al = new ArrayList();
            float mxX = 0;
            float mxY = 0;
            for (int n = 0; n < flnms.Length; n++)
            {
                string[] lns = File.ReadAllLines(flnms[n]);
                for (int i = 1; i < lns.Length; i++)
                {
                    string[] wrds = lns[i].Split(':');
                    float[] dt = new float[2 * wrds.Length];
                    for (int j = 0; j < wrds.Length; j++)//wrds[j]=[x1,y1:x2,y2:x3,y3:x4,y4]
                    {
                        string[] s2 = wrds[j].Split(',');
                        dt[j * 2] = float.Parse(s2[0]);
                        dt[j * 2+1] = float.Parse(s2[1]);
                        mxX = Math.Max(mxX, dt[j * 2]);
                        mxY = Math.Max(mxY, dt[j * 2 + 1]);
                    }
                    al.Add(dt);
                }
            }
            train.inData = new double[al.Count][];
            train.outData = new double[al.Count][];
            int inl = train.inData.Length;
            int outl = train.outData.Length;
            for (int n = 0; n < al.Count; n++)
            {

                float[] dt = (float[])al[n];
                float[] dtn = new float[dt.Length];
                for (int j = 0; j < dt.Length; j+=2)
                {
                    dtn[j] = dt[j] / mxX;
                    dtn[j+1] = dt[j + 1] / mxY;
                }
                float d1 = DistanceP1P2(dtn[0], dtn[1], dtn[2], dtn[3]);//dist(p1,p2)
                float d2 = DistanceP1P2(dtn[0], dtn[1], dtn[4], dtn[5]);//dist(p1,p3)
                float d3 = DistanceP1P2(dtn[2], dtn[3], dtn[4], dtn[5]);//dist(p2,p3)
                float d4 = DistanceP1P2(dtn[0], dtn[1], dtn[6], dtn[7]);//dist(p1,p4)
                float d5 = DistanceP1P2(dtn[2], dtn[3], dtn[6], dtn[7]);//dist(p2,p4)
                float d6 = DistanceP1P2(dtn[4], dtn[5], dtn[6], dtn[7]);//dist(p3,p4)
                //Inputs=>x1,y1,x2,y2,x3,y3,d1,d2,d3,d4,d5,d6
                train.inData[n] = new double[12];
                train.inData[n][0] = dtn[0];//x1
                train.inData[n][2] = dtn[1];//x2
                train.inData[n][4] = dtn[2];//x3
                train.inData[n][1] = dtn[3];//y1
                train.inData[n][3] = dtn[4];//y2
                train.inData[n][5] = dtn[5];//y3
                train.inData[n][6] = d4;
                train.inData[n][7] = d5;
                train.inData[n][8] = d6;
                //train.inData[n][9] = d1;
                //train.inData[n][10] = d2;
                //train.inData[n][11] = d3;
                //Outputs=>x4,y4
                train.outData[n] = new double[2];
                train.outData[n][0] = dtn[6];//x4
                train.outData[n][1] = dtn[7];//y4
            }
        }
        //*********************************************************
        private float DistanceP1P2(float x1, float y1, float x2, float y2)
        {
            float dist = (float)Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            return dist;
        }
        //*********************************************************
        private void btnLoadNet_Click(object sender, EventArgs e)//Visibil=False
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
            vnnproj = ldsv.proj;
            train = new TrainThisNet();
            train.demo = this;
            train.proj = vnnproj;

        }
        //*********************************************************
        private void btnSaveNet_Click(object sender, EventArgs e)//Visibil=False
        {
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
            netFlnm = saveFileDialog1.FileName;
            File.WriteAllText(@"netPath.txt", netFlnm);

            VnnBpLib.VnnBpLodSav ldsv = new VnnBpLib.VnnBpLodSav(vnnproj);
            ldsv.SaveProjFile(netFlnm);
            string buf = File.ReadAllText(netFlnm);
        }
        //*********************************************************
        private void btnSaveData_Click(object sender, EventArgs e)//Visibil=False
        {
            string dataFlnm = "";
            if (File.Exists(@"dataPath.txt"))
            {
                dataFlnm = File.ReadAllText(@"dataPath.txt");
            }
            saveFileDialog1.Title = "Enter Save Data File Name(*.csv)";
            saveFileDialog1.InitialDirectory = dataFlnm;
            saveFileDialog1.FileName = dataFlnm;
            saveFileDialog1.Filter = "Data (*.csv)|*.csv|" + "All files (*.*)|*.*";
            DialogResult r = saveFileDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.Cancel)
                return;
            dataFlnm = saveFileDialog1.FileName;
            File.WriteAllText(@"dataPath.txt", dataFlnm);
            SaveData(dataFlnm);
        }
        //*********************************************************
        private void SaveData(string dataFlnm)
        {
            string hdr = "SNo,";
            for (int i = 0; i < train.inData[0].Length; i++)
                hdr += "Di" + i.ToString().PadLeft(2, '0') + ",";
            for (int i = 0; i < train.outData[0].Length; i++)
                hdr += "Do" + i.ToString().PadLeft(2, '0') + ",";
            hdr = hdr.TrimEnd(',');
            string page = hdr;
            for (int n = 0; n < train.inData.Length; n++)
            {
                string ln = "\n" + n.ToString() + ",";
                for (int i = 0; i < train.inData[n].Length; i++)
                    ln += train.inData[n][i].ToString() + ",";
                for (int i = 0; i < train.outData[n].Length; i++)
                    ln += train.outData[n][i].ToString() + ",";
                ln = ln.TrimEnd(',');
                page += ln;
            }
            File.WriteAllText(dataFlnm, page);
        }
        //*********************************************************
        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpDoc helpdoc = new HelpDoc();
            helpdoc.Show();
        }
        //*********************************************************
        private void pbxNetVw_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (train == null)
                    return;
                train.InitializeNeuronsPosition2();
                train.PlotNetAll();
                pbxNetVw.Image = train.pictureBox2.Image;
            }
        }
        //*********************************************************
    }
}
