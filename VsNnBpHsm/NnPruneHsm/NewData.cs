using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using VnnBpLib;

namespace VnnBp
{
    public partial class NewData : Form
    {
        //*********************************************************
        public VnnBpLib.VnnBpProj proj;
        public TrainThisNet train;
        ImageIO imageio;
        Random rnd=new Random(DateTime.Now.Millisecond);
        //*********************************************************
        public NewData()
        {
            InitializeComponent();
        }
        //*********************************************************
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //*********************************************************
        private void NewData_Shown(object sender, EventArgs e)
        {
            int mxin = proj.vnnnet[0].inputs.Length;
            int mxout = proj.vnnnet[0].outputs.Length;
            string page = "Max Ins:" + mxin.ToString() + "\n";
            page+="Max Outs:"+mxout.ToString();
            richTextBox1.Text = page;
            imageio = new ImageIO();
            imageio.proj = proj;
            btnLoadData.Focus();
        }
        //*********************************************************
        private void btnNewData_Click(object sender, EventArgs e)
        {//Load NN Inputs outputs with XOR data 
          
            int mxin = proj.vnnnet[0].inputs.Length;
            int mxout = proj.vnnnet[0].outputs.Length;
            if (proj.vnnnet[0].inputs.Length == 2 * proj.vnnnet[0].outputs.Length)
            {
                int mxSmpls = int.Parse(txbxSmpls.Text);
                train.inData = new double[mxSmpls][];
                train.outData = new double[mxSmpls][];
                for (int n = 0; n < mxSmpls; n++)
                {
                    train.inData[n] = new double[mxin];
                    for (int i = 0; i < mxin; i++)
                    {
                        train.inData[n][i] = rnd.Next(2);
                    }
                    train.outData[n] = new double[mxout];
                    for (int i = 0; i < mxout; i++)
                    {
                        train.outData[n][i]
                            = (int)train.inData[n][i * 2]
                            ^ (int)train.inData[n][i * 2 + 1];
                    }
                }
            }
            else
            {
                MessageBox.Show("Input-Output Size Mismatch");
            }
        }
        //*********************************************************
        private void btnSaveData_Click(object sender, EventArgs e)
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
                string ln = "\n"+n.ToString()+",";
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
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            string dataFlnm = "";
            if (File.Exists(@"dataPath.txt"))
            {
                dataFlnm = File.ReadAllText(@"dataPath.txt");
            }
            openFileDialog1.InitialDirectory = dataFlnm;
            openFileDialog1.FileName = dataFlnm;
            openFileDialog1.Title = "Point to Data File(*.csv)";
            openFileDialog1.Filter = "Data (*.csv)|*.csv|" + "All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            dataFlnm = openFileDialog1.FileName;
            File.WriteAllText(@"dataPath.txt", dataFlnm);
            LoadData(dataFlnm);
            btnExit.Focus();
        }
        //*********************************************************
        private void LoadData(string dataFlnm)
        {
            string[] lns = File.ReadAllLines(dataFlnm);
            string[] hdr = lns[0].Split(',');
            int mxIn = 0;
            int mxOut = 0;
            for (int i = 0; i < hdr.Length; i++)
            {
                if (hdr[i].Contains("Di"))
                    mxIn++;
                if (hdr[i].Contains("Do"))
                    mxOut++;
            }
            train.inData = new double[lns.Length - 1][];
            train.outData = new double[lns.Length - 1][];
            for (int n = 1; n < lns.Length; n++)
            {
                train.inData[n - 1] = new double[mxIn];
                train.outData[n - 1] = new double[mxOut];
                string[] wrds = lns[n].Split(',');
                int k = 1;
                for (int i = 0; i < mxIn; i++)
                {
                    train.inData[n - 1][i] = double.Parse(wrds[k]);
                    k++;
                }
                for (int i = 0; i < mxOut; i++)
                {
                    train.outData[n - 1][i] = double.Parse(wrds[k]);
                    k++;
                }
            }
            txbxSmpls.Text = (lns.Length - 1).ToString();
        }
        //*********************************************************
        private void btnSaveWsnData_Click(object sender, EventArgs e)
        {
            if (proj == null)
            {
                MessageBox.Show("No Net File Loaded");
                return;
            }
            NewData newdata = new NewData();
            newdata.proj = proj;
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
            btnSaveData_Click(null, null);
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
                        dt[j * 2 + 1] = float.Parse(s2[1]);
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
                for (int j = 0; j < dt.Length; j += 2)
                {
                    dtn[j] = dt[j] / mxX;
                    dtn[j + 1] = dt[j + 1] / mxY;
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
        private void btnImage_Click(object sender, EventArgs e)
        {

            if (imageio.Visible)
            {
                imageio.Hide();
            }
            else
            {
                imageio.Show();
            }
        }
        //*********************************************************
    }
}
