using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using VnnBpLib;

namespace VnnBp
{
    public partial class ImageIO : Form
    {
        //**********************************************************
        public VnnBpLib.VnnBpProj proj;
        Random rnd = new Random(DateTime.Now.Millisecond);
        //**********************************************************
        public ImageIO()
        {
            InitializeComponent();
        }
        //**********************************************************
        private void ImageIO_Shown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < proj.vnnnet[proj.selNet].neuron.Length; i++)
            {
                comboBox1.Items.Add(i + 1);
            }
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
        }
        //**********************************************************
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //**********************************************************
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //**********************************************************
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < proj.vnnnet[proj.selNet].neuron.Length; i++)
            {
                comboBox1.Items.Add(i + 1);
            }
            if (comboBox1.SelectedIndex<0)
                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            if (comboBox1.SelectedIndex > comboBox1.Items.Count - 1)
                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            int si = comboBox1.SelectedIndex;
            int nno = (int)comboBox1.Items[si] - 1;
            //int nno = int.Parse(comboBox1.SelectedText);
            Bitmap bm1 = (Bitmap)pictureBox1.Image;
            Bitmap bm2 = new Bitmap(bm1.Width, bm1.Height);
            for (int y = 0; y < bm1.Height; y++)
            {
                double yr = (double)y / bm1.Height;
                for (int x = 0; x < bm1.Width; x++)
                {
                    double xr = (double)x / bm1.Width;
                    proj.vnnnet[proj.selNet].inputs[0].value = xr;
                    proj.vnnnet[proj.selNet].inputs[0].sno = 0;
                    proj.vnnnet[proj.selNet].inputs[1].value = yr;
                    proj.vnnnet[proj.selNet].inputs[1].sno = 1;
                    proj.vnnnet[proj.selNet].UpdateNet();
                    double val = proj.vnnnet[proj.selNet].neuron[nno].nuOut;
                    byte vi = (byte)(255 * val);
                    bm2.SetPixel(x, y, Color.FromArgb(vi, vi, vi));
                }
            }
            pictureBox2.Image=bm2;
        }
        //**********************************************************
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string tngFlNm = "";
            if (File.Exists(@"tngPath.txt"))
            {
                tngFlNm = File.ReadAllText(@"tngPath.txt");
            }
            openFileDialog1.InitialDirectory = tngFlNm;
            openFileDialog1.FileName = tngFlNm;
            openFileDialog1.Title = "Select Training Image File(*.bmp)";
            openFileDialog1.Filter = "Image (*.bmp)|*.bmp|" + "All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            tngFlNm = openFileDialog1.FileName;
            File.WriteAllText(@"tngPath.txt", tngFlNm);

            proj.vnnnet[proj.selNet].bm1 = new Bitmap(tngFlNm);
            pictureBox1.Image = proj.vnnnet[proj.selNet].bm1;
        }
        //**********************************************************
        private void btnSave_Click(object sender, EventArgs e)
        {
            string tngFlNm = "";
            if (File.Exists(@"tngPath.txt"))
            {
                tngFlNm = File.ReadAllText(@"tngPath.txt");
            }
            saveFileDialog1.Title = "Enter Save File Name(*.csv)";
            saveFileDialog1.InitialDirectory = tngFlNm;
            saveFileDialog1.FileName = tngFlNm;
            saveFileDialog1.Filter = "CSV (*.csv)|*.csv|" + "All files (*.*)|*.*";
            DialogResult r = saveFileDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.Cancel)
                return;
            tngFlNm = saveFileDialog1.FileName;
            File.WriteAllText(@"tngPath.txt", tngFlNm);

            Bitmap bm = (Bitmap)pictureBox1.Image;
            int xmx = bm.Width;
            int ymx = bm.Height;
            int smx = int.Parse(txbxSamples.Text);
            int wht = 0;
            int blk = 0;
            string page = "SNo,Di00,Di01,Do00";
            for (int i = 0; i < smx; i++)
            {
                int x = rnd.Next(xmx);
                int y = rnd.Next(ymx);
                Color col = bm.GetPixel(x, y);
                float xn = (float)x / xmx;
                float yn = (float)y / ymx;
                xn = (float)Math.Round(xn, 4);
                yn = (float)Math.Round(yn, 4);
                page += "\n" + i.ToString() + "," + xn.ToString() + "," + yn.ToString() + ",";
                if (col == Color.FromArgb(0, 0, 0))
                    page += "0";
                else
                    page += "1";
            }
            File.WriteAllText(tngFlNm, page);
            return;
        }
        //**********************************************************
    }
}