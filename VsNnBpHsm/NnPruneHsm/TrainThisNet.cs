using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using VnnBp.Properties;
using VnnBpLib;


namespace VnnBp
{
    public enum FunType { NIL, YX, EXP1, EXP2 };
    public enum EditType { VIEW, DRAG, FUN, DEL };

    public partial class TrainThisNet : Form
    {
        //*********************************************************
        Random rnd = new Random(DateTime.Now.Millisecond);
        public VnnBpLib.VnnBpProj proj;
        public VnnBpDemo demo;
        ImageIO imageio;
        public double[][] inData;
        public double[][] outData;
        double minErr = double.MaxValue;
        double[] errbuf;
        double errMx = 1;
        double errAvgLmt = 1;
        int ptr = 0;
        int zm = 1;
        int pz = 0;
        int thisNet = -1;
        long count = 0;
        double enlrg = 1.01;
        int pronCount = 0;
        double pruneMin = 0;
        int bakno;
        string workPath = "";
        //*********************************************************
        public TrainThisNet()
        {
            InitializeComponent();
        }
        //*********************************************************
        private void TrainThisNet_Shown(object sender, EventArgs e)
        {
            thisNet = proj.selNet;
            //LoadData(false);//Hsm 21072023            
            int netno = proj.selNet + 1;//proj.selNet is zero-index
            lblNetNum.Text = netno.ToString();
            lblNetNm.Text = proj.vnnnet[proj.selNet].netName;
            errbuf = new double[pictureBox1.Width];
            PlotError();
            imageio = new ImageIO();
            imageio.proj = proj;
            lblNuMx.Text = proj.vnnnet[thisNet].maxNeurons.ToString();
            lblConMx.Text = proj.vnnnet[thisNet].maxConnections.ToString();
            panel2.Refresh();
            this.Location = proj.vnnnet[proj.selNet].pos;
            tsComboNu.Items.Clear();
            tsComboNu.Items.Add("Nu View.");
            tsComboNu.Items.Add("Nu Drag");
            tsComboNu.Items.Add("Nu Fun.");
            tsComboNu.Items.Add("Nu Del.");
            tsComboNu.SelectedIndex = 0;
            tsComboNuFun.Items.Clear();//"nil", "y=x", "exp+", "exp+-", "sqrt"
            tsComboNuFun.Items.Add("nil");
            tsComboNuFun.Items.Add("y=x");
            tsComboNuFun.Items.Add("exp+");
            tsComboNuFun.Items.Add("exp+-");
            tsComboNuFun.Items.Add("sqrt");
            tsComboNuFun.SelectedIndex =  0;
            tsComboNuFun.Visible = false;

            InitializeNeuronsPosition2();
            PlotNetAll();
            btnRand.Focus();
        }
        //*********************************************************
        private void PlotError()
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(Color.Black);
            double ky = 0.95 * bm.Height / errMx;
            //for (int x = 1; x < bm.Width-1; x++)
            for (int x = 1; x < ptr; x++)
            {
                int y1 = (int)(ky * errbuf[x - 1]);
                int y2 = (int)(ky * errbuf[x]);
                g.DrawLine(Pens.Yellow, x - 1, y1, x, y2);
            }
            g.Dispose();
            bm.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Image = bm;
        }
        //*********************************************************
        private void LoadData(bool tst)
        {
            //string fol1 = Directory.GetParent(proj.projFileName).Parent.FullName + @"\Data";
            string fol1 = "";
            string tngFlNm = fol1 + @"\TngDt" + thisNet.ToString().PadLeft(3, '0') + ".csv";
            string tstFlNm = fol1 + @"\TstDt" + thisNet.ToString().PadLeft(3, '0') + ".csv";
            string flnm = "";
            if (tst)
                flnm = tstFlNm;
            else flnm = tngFlNm;
            if (!File.Exists(flnm))
            {
                MessageBox.Show("No training file exists");
                //this.Hide();
                return;
            }
            ArrayList al = new ArrayList();
            StreamReader sr1 = new StreamReader(flnm);
            for (; ; )
            {
                string ln = sr1.ReadLine();
                if (ln == null)
                    break;
                al.Add(ln);
            }
            sr1.Close();
            if (al.Count <= 0)
            {
                MessageBox.Show("No training data exists");
                this.Hide();
                return;
            }
            inData = new double[al.Count - 1][];
            outData = new double[al.Count - 1][];
            string[] wrds = al[0].ToString().Split(',');
            int maxIn = 0;
            int maxOut = 0;
            for (int i = 0; i < wrds.Length; i++)
            {
                if (wrds[i].Contains("DI"))
                {
                    maxIn++;
                }
                if (wrds[i].Contains("DO"))
                {
                    maxOut++;
                }
            }
            for (int i = 0; i < inData.Length; i++)
            {
                inData[i] = new double[maxIn];
                outData[i] = new double[maxOut];
                string[] wrds2 = al[i + 1].ToString().Split(',');
                for (int j = 0; j < maxIn; j++)
                {
                    inData[i][j] = double.Parse(wrds2[j + 1]);
                }
                for (int j = 0; j < maxOut; j++)
                {
                    outData[i][j] = double.Parse(wrds2[j + 1 + maxIn]);
                }
            }
            errAvgLmt = maxOut / 2.0;
        }    
        //*********************************************************
        private void btnExit_Click(object sender, EventArgs e)
        {
            btnTrainStop.Text = "Train";
            timer1.Stop();
            this.Hide();
        }
        //*********************************************************
        private void btnTrainStop_Click(object sender, EventArgs e)
        {
             if (btnTrainStop.Text == "Train")
            {
                if (inData == null)
                {
                    MessageBox.Show("Load Data");
                    this.Hide();
                    return;
                }
                panel2.Visible = true;
                //panel1.Visible = false;
                //LoadData(false); //Hsm 25072023
                minErr = double.MaxValue;
                btnTrainStop.Text = "Stop";
                timer1.Interval = 10;
                timer1.Start();
            }
            else
            {
                btnTrainStop.Text = "Train";
                timer1.Stop();
            }
        }
        //*********************************************************
        private void TestCompleteSet()
        {

                btnTrainStop.Text = "Train";
                timer1.Stop();
            double error = 0;
            int intError = 0;
            int cnMx = inData.Length;
            int pn = 0;
            int tp = 0;
            int tn = 0;
            int fp = 0;
            int fn = 0;

            for (int n = 0; n < cnMx; n++)
            {
                int rn = n;

                for (int i = 0; i < proj.vnnnet[thisNet].maxInputs; i++)
                {
                    proj.vnnnet[thisNet].inputs[i].value = inData[rn][i];
                }
                for (int i = 0; i < proj.vnnnet[thisNet].maxOutputs; i++)
                {
                    proj.vnnnet[thisNet].outputs[i].value = outData[rn][i];
                    if (outData[rn][i] > 0.5)
                        pn++;
                }
                proj.vnnnet[thisNet].UpdateNet();
                double err2 = proj.vnnnet[thisNet].GetAllErrors();
                //double err2 = proj.vnnnet[thisNet].ReinforceConnections();
                error += err2;
                intError += proj.vnnnet[thisNet].intErr;
                tp += proj.vnnnet[thisNet].tp;
                tn += proj.vnnnet[thisNet].tn;
                fp += proj.vnnnet[thisNet].fp;
                fn += proj.vnnnet[thisNet].fn;
            }
            //lblTp.Text = tp.ToString();
            //lblTn.Text = tn.ToString();
            //lblFp.Text = fp.ToString();
            //lblFn.Text = fn.ToString();
            int outMx = proj.vnnnet[thisNet].outputs.Length;
            float errorP = (float)(error * 100f / (cnMx * outMx));
            //float errorP2 = (float)(error * 100f / (tp * outMx));
            double dt2 = Math.Round(errorP, 4);
            double dt = Math.Round(error, 4);
            lblErr.Text = (100f - dt2).ToString();

        }
        //*********************************************************
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (thisNet < 0)
            {
                btnTrainStop.Text = "Train";
                timer1.Stop();
            }
            double error = 0;
            int intError = 0;
            int cnMx = 10000;
            int tp = 0;
            for (int n = 0; n < cnMx; n++)
            {
                int rn = rnd.Next(inData.Length);

                for (int i = 0; i < proj.vnnnet[thisNet].maxInputs; i++)
                {
                    proj.vnnnet[thisNet].inputs[i].value = inData[rn][i];
                }
                for (int i = 0; i < proj.vnnnet[thisNet].maxOutputs; i++)
                {
                    proj.vnnnet[thisNet].outputs[i].value = outData[rn][i];
                    if(outData[rn][i]>0.5)
                    tp ++;
                }
                proj.vnnnet[thisNet].UpdateNet();
                double err2 = proj.vnnnet[thisNet].ReinforceConnections();
                error += err2;
                intError += proj.vnnnet[thisNet].intErr;
            }
            proj.vnnnet[thisNet].EnlargeConnectionsWgt(enlrg);
            if (enlrg > 1.00)
            {
                if ((minErr * 1.25) < error)//
                    enlrg = 1.00;
                if (intError == 0)
                    enlrg = 1.00;
            }
            int outMx = proj.vnnnet[thisNet].outputs.Length;
            float errorP = (float)(error * 100f / (cnMx * outMx));
            float errorP2 = (float)(error * 100f / (tp * outMx));
            double dt2 = Math.Round(errorP, 4);
            double dt = Math.Round(error, 4);
            lblErr.Text = (100f-dt2).ToString();

            if (minErr > dt2)
            {
                minErr = dt2;
                proj.vnnnet[thisNet].lastErr = minErr;
                //proj.vnnnet[thisNet].SaveThisWeights();
            }
            //if (error / minErr > 1.1)
            //{
            //    proj.vnnnet[thisNet].RestoreOriginalWeights();
            //}
            if (errMx < dt)
            {
                errMx = dt;
            }
            lblMinErr.Text = (100f-minErr).ToString();
            lblIntErr.Text = intError.ToString();
            pz++;
            if (pz >= zm)
            {
                PlotError();
                errbuf[ptr] = error;
                pz = 0;
                ptr++;
                if (ptr >= errbuf.Length)
                {
                    for (int i = 0; i < errbuf.Length; i+=2)
                    {
                        errbuf[i/2] = (errbuf[i] + errbuf[i + 1]) / 2;
                        errbuf[i] = errbuf[i + 1] = 0;
                    }
                    ptr = ptr / 2;
                    zm *= 2;
                }
            }
            lblCount.Text = count.ToString();
            //.............................................
            count += 1;
        }
        //*********************************************************
        private void btnRand_Click(object sender, EventArgs e)
        {
            proj.vnnnet[thisNet].SetRandomWeights();
            minErr = double.MaxValue;
            proj.vnnnet[thisNet].lastErr = double.MaxValue;
            errMx = 0;
            ptr = 0;
            zm = 1;
            enlrg = 1.01;
            count = 0;
            InitializeNeuronsPosition2();
            PlotNetAll();
            btnTrainStop.Focus();
        }
        //*********************************************************
        private void btnEta_Click(object sender, EventArgs e)
        {
            double eta = double.Parse(txbxEta.Text);
            proj.vnnnet[thisNet].eta = eta;
            proj.vnnnet[thisNet].etab = eta;
        }
        //*********************************************************
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            proj.selNet = (short)thisNet;
            //demo.PlotNetAll();
            //demo.HighlightNet(proj.selNet);
        }
        //*********************************************************
        private void btnPrune_Click(object sender, EventArgs e)
        {
            //PruneNet();
            //FixNeuronConnSize();
            //minErr = double.MaxValue;
            //proj.vnnnet[thisNet].SaveThisWeights();
            //int smax1 = 10000;
            //double error1 = get_total_error(smax1);
            //double error2 = get_total_error(smax1);
            //proj.vnnnet[proj.selNet].remove_connections(0);
            //double error3 = get_total_error(smax1);
            //proj.vnnnet[thisNet].SetRandomWeights();
            //proj.vnnnet[thisNet].RestoreOriginalWeights();
            //return;
        }
        //*********************************************************
        private void btnPrune_MouseDown(object sender, MouseEventArgs e)
        {
            panel2.Visible = true;
            //panel1.Visible = false;
            lblNuMx.Text = proj.vnnnet[thisNet].maxNeurons.ToString();
            lblConMx.Text = proj.vnnnet[thisNet].maxConnections.ToString();
            panel2.Refresh();
            if (e.Button == MouseButtons.Left)
            {
                proj.vnnnet[thisNet].SavePrePrineWeights();
                PruneNet();
                FixNeuronConnSize();
                minErr = double.MaxValue;
            }
            if (e.Button == MouseButtons.Right)
            {
               // proj.vnnnet[thisNet].RestorePrePrineWeights();
                //demo.PlotNetAll();
                //demo.HighlightNet(proj.selNet);
            }
            lblNuMx.Text = proj.vnnnet[thisNet].maxNeurons.ToString();
            lblConMx.Text = proj.vnnnet[thisNet].maxConnections.ToString();
            panel2.Refresh();
            PlotNetAll();
            demo.pbxNetVw.Image = pictureBox2.Image;            
        }
        //*********************************************************
        private void PruneNet()
        {
            float prunK = float.Parse(txbxPrun.Text);
            int p = 0;
            int smax = 10000;
            double errOrg = prunK * get_total_error(smax);//was 4.0
            int over = 0;
            int wout = proj.vnnnet[proj.selNet].conn.Length / 2;//was2
            proj.vnnnet[proj.selNet].maxConnections = proj.vnnnet[proj.selNet].conn.Length;
            do
            {
                proj.vnnnet[thisNet].SaveThisWeights();
                proj.vnnnet[proj.selNet].remove_connections(wout);
                double error = get_total_error(smax);
                if (error > errOrg)
                {
                    proj.vnnnet[thisNet].RestoreOriginalWeights();
                    wout = wout / 2;//2
                }
                if (wout == 0) over = 1;
                p++;
                if (p > 100)
                    over = 1;
            } while (over == 0);
            proj.vnnnet[thisNet].RestoreOriginalWeights();

            proj.vnnnet[proj.selNet].remove_neurons();
            proj.vnnnet[proj.selNet].remove_neurons();
            proj.vnnnet[proj.selNet].remove_neurons();
            proj.vnnnet[proj.selNet].remove_neurons();
            proj.vnnnet[proj.selNet].remove_neurons();
            proj.vnnnet[proj.selNet].UpdateNuLayers();

            //demo.PlotNetAll();
            //demo.HighlightNet(proj.selNet);
        }
        //*********************************************************
        private void FixNeuronConnSize()
        {
            ArrayList alC = new ArrayList();
            for (int i = 0; i < proj.vnnnet[thisNet].maxConnections; i++)
            {
                alC.Add(proj.vnnnet[thisNet].conn[i]);
            }
            proj.vnnnet[thisNet].conn = new VnnBpLib.VnnBpConnection[proj.vnnnet[thisNet].maxConnections];
            for (int i = 0; i < proj.vnnnet[thisNet].maxConnections; i++)
            {
                proj.vnnnet[thisNet].conn[i] = (VnnBpLib.VnnBpConnection)alC[i];
            }
            ArrayList alN = new ArrayList();
            for (int i = 0; i < proj.vnnnet[thisNet].maxNeurons; i++)
            {
                alN.Add(proj.vnnnet[thisNet].neuron[i]);
            }
            proj.vnnnet[thisNet].neuron = new VnnBpLib.VnnBpNeuron[proj.vnnnet[thisNet].maxNeurons];
            for (int i = 0; i < proj.vnnnet[thisNet].maxNeurons; i++)
            {
                proj.vnnnet[thisNet].neuron[i] = (VnnBpLib.VnnBpNeuron)alN[i];
            }
        }
         //*********************************************************
        public double get_total_error(int smax)
        {
            int s;
            double totalerr = 0.0;
            int intError = 0;
            for (s = 0; s < smax; s++)
            {
                int rn = rnd.Next(inData.Length);
                for (int i = 0; i < proj.vnnnet[thisNet].maxInputs; i++)
                {
                    proj.vnnnet[thisNet].inputs[i].value = inData[rn][i];
                }
                for (int i = 0; i < proj.vnnnet[thisNet].maxOutputs; i++)
                {
                    proj.vnnnet[thisNet].outputs[i].value = outData[rn][i];
                }
                proj.vnnnet[thisNet].UpdateNet();
                double err2 = proj.vnnnet[thisNet].ReinforceConnections();
                totalerr += err2;
                intError += proj.vnnnet[thisNet].intErr;
            }
            return (totalerr);
        }
        //*********************************************************
        public Bitmap GetOutputImage()
        {
            LoadData(true);//load test data
            Bitmap b = proj.vnnnet[thisNet].bm1;
            int w = b.Width;
            int h = b.Height;
            for (int s = 0; s < inData.Length; s++)
            {
                int rn = rnd.Next(inData.Length);
                for (int i = 0; i < proj.vnnnet[thisNet].maxInputs; i++)
                {                    proj.vnnnet[thisNet].inputs[i].value = inData[rn][i];
                }
                 proj.vnnnet[thisNet].UpdateNet();
                 int x = (int)(w * proj.vnnnet[thisNet].inputs[0].value);
                 int y = (int)(h * proj.vnnnet[thisNet].inputs[1].value);
            }
            return b;
        }
        //*********************************************
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
        private void btnTest_Click(object sender, EventArgs e)
        {
            //panel1.Visible = true;
            panel2.Visible = false;
            string tmp = txbxEta.Text;
            txbxEta.Text = "0";
            txbxEta.Refresh();
            proj.vnnnet[thisNet].eta = 0;
            proj.vnnnet[thisNet].etab = 0;
            //panel1.Visible = true;
            TestCompleteSet();
            txbxEta.Text = tmp;
            double eta = double.Parse(txbxEta.Text);
            proj.vnnnet[thisNet].eta = eta;
            proj.vnnnet[thisNet].etab = eta;
        }
        //*********************************************************
        private void label15_Click(object sender, EventArgs e)
        {
            if (label15.Text == "Prune")
            {
                bakno = 1;
                label15.Text = "Stop";
                pronCount = 0;
                pruneMin = double.Parse(lblMinErr.Text);
                timer2.Interval = 60000;
                timer2.Start();
            }
            else
            {
                timer2.Stop();
                label15.Text = "Prune";
            }
        }
        //*********************************************************
        private void timer2_Tick(object sender, EventArgs e)
        {
            pronCount++;
            label15.Text = "Stop" + pronCount.ToString();
            double pruneMinErr = double.Parse(lblMinErr.Text);
            if (pruneMinErr > pruneMin)
            {
                //if (proj.projFileName == null)
                //    return;
                //FileInfo fi = new FileInfo(proj.projFileName);
                //string foldernm = proj.projFileName.Replace(".npj", "");
                //string projnm = fi.Name.Replace(".npj", "");
                VnnBpLib.VnnBpLodSav ldsv = new VnnBpLib.VnnBpLodSav(proj);
                ldsv.SaveProjFile(proj.projFileName+bakno.ToString());
                bakno++;


                //proj.sSaveNewProjectFile(proj.projFileName);
                panel2.Visible = true;
                //panel1.Visible = false;
                lblNuMx.Text = proj.vnnnet[thisNet].maxNeurons.ToString();
                lblConMx.Text = proj.vnnnet[thisNet].maxConnections.ToString();
                panel2.Refresh();
                proj.vnnnet[thisNet].SavePrePrineWeights();
                PruneNet();
                FixNeuronConnSize();
                minErr = double.MaxValue;
                pronCount = 0;
                label15.Text = "Stop" + pronCount.ToString();
            }
            if (pronCount > 30)
            {
                timer2.Stop();
                label15.Text = "Prune";
            }
        }
        //*********************************************************
        private void TrainThisNet_LocationChanged(object sender, EventArgs e)
        {
          //  this.Location = proj.vnnnet[proj.selNet].pos;
        }
        //*********************************************************
        private void label1_Click(object sender, EventArgs e)
        {
            lblConMx.Text = proj.vnnnet[thisNet].maxConnections.ToString();
        }
        //*********************************************************
        private void label16_Click(object sender, EventArgs e)
        {
            lblNuMx.Text = proj.vnnnet[thisNet].maxNeurons.ToString();
        }
        //**********************************************************
        private void DrawGrid(PictureBox pbox, int nx, int ny, int gx, int gy)
        {
            Pen pn = new Pen(Color.FromArgb(255, 200, 200), 1);
            Bitmap b = new Bitmap(gx * nx, gy * ny);
            Graphics g = Graphics.FromImage(b);
            g.FillRectangle(Brushes.LemonChiffon, new Rectangle(0, 0, b.Width, b.Height));
            for (int x = 0; x < b.Width; x += gx)
            {
                g.DrawLine(pn, new Point(x, 0), new Point(x, b.Height - 1));
            }
            for (int y = 0; y < b.Height; y += gy)
            {
                g.DrawLine(pn, new Point(0, y), new Point(b.Width - 1, y));
            }
            g.Dispose();
            pbox.Size = b.Size;
            pbox.Image = b;
        }
        //**********************************************************
        public struct GridMap
        {
            public short pos;
            public short netno;
        };
        int gx = 16;//grid width in pixels 
        int gy = 16;//grid height in pixels 
        int gnx = 130;//max horizental grid cells
        int gny = 120;//max vertical grid cells
        int magx = 4;//Grid cells per Net Column wirth
        int magy = 1;//Grid cells per Net Column height
        private VnnBpLib.VnnBpProj vnnproj;
        GridMap[,] grdMap;
        Point mouseDn;
        int nuNum;
        //**********************************************************
        public void PlotNetAll()
        {
            DrawGrid(pictureBox2, gnx, gny, gx, gy);
//            grdMap = new GridMap[gnx, gny];
            vnnproj = proj;
            if (vnnproj == null)
                return;
            if (vnnproj.vnnnet == null)
                return;
            if (vnnproj.vnnnet.Length == 0)
                return;
            for (int netNo = 0; netNo < vnnproj.vnnnet.Length; netNo++)
            {
                Pen pen = Pens.Blue;
                int ins = vnnproj.vnnnet[netNo].maxInputs;
                int outs = vnnproj.vnnnet[netNo].maxOutputs;
                int nus = vnnproj.vnnnet[netNo].maxNeurons;
                int cons = vnnproj.vnnnet[netNo].maxConnections;
                int[] lyrs = vnnproj.vnnnet[netNo].nuLayers;

                for (int n = 0; n < vnnproj.vnnnet[netNo].maxConnections; n++) //for (int n = 0; n < vnnproj.vnnnet[netNo].conn.Length; n++)
                {
                    int sn = vnnproj.vnnnet[netNo].conn[n].srcNuNo;
                    int dn = vnnproj.vnnnet[netNo].conn[n].dstNuNo;
                    int x1 = vnnproj.vnnnet[netNo].neuron[sn].gridPos.X;
                    int y1 = vnnproj.vnnnet[netNo].neuron[sn].gridPos.Y;
                    int x2 = vnnproj.vnnnet[netNo].neuron[dn].gridPos.X;
                    int y2 = vnnproj.vnnnet[netNo].neuron[dn].gridPos.Y;
                    DrawConnection(x1, y1, x2, y2, Pens.Gray);
                }

                for (int k = 0; k < vnnproj.vnnnet[netNo].neuron.Length; k++)
                {
                    int x0 = vnnproj.vnnnet[netNo].neuron[k].gridPos.X;
                    int y0 = vnnproj.vnnnet[netNo].neuron[k].gridPos.Y;
                    if ((x0 >= 0) & (y0 >= 0))
                    {
                        grdMap[x0, y0].pos = (short)(k + 1);//none number 
                        grdMap[x0, y0].netno = (short)(netNo + 1);
                    }
                    switch (vnnproj.vnnnet[netNo].neuron[k].ihono)
                    {
                        case VnnBpLib.NuType.None://none
                            break;
                        case VnnBpLib.NuType.In://input nuron
                            DrawInputNeuron(x0, y0, Pens.Blue);
                            break;
                        case VnnBpLib.NuType.Hdn://hidden nuron
                            if (vnnproj.vnnnet[netNo].neuron[k].funno != 2)
                            {
                                Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
                                DrawHiddenNeuron(x0, y0, blackPen);
                            }
                            else
                                DrawHiddenNeuron(x0, y0, Pens.Black);
                            break;
                        case VnnBpLib.NuType.Out://output nuron
                            DrawOutputNeuron(x0, y0, Pens.Red);
                            break;
                    };
                }
            }
            if (vnnproj.connP != null)
            {
                for (int i = 0; i < vnnproj.connP.Length; i++)
                {
                    int snet = vnnproj.connP[i].srcNetNo;
                    int dnet = vnnproj.connP[i].dstNetNo;
                    int snu = vnnproj.connP[i].srcNuNo;
                    int dnu = vnnproj.connP[i].dstNuNo;
                    int x1 = vnnproj.vnnnet[snet].neuron[snu].gridPos.X;
                    int y1 = vnnproj.vnnnet[snet].neuron[snu].gridPos.Y;
                    int x2 = vnnproj.vnnnet[dnet].neuron[dnu].gridPos.X;
                    int y2 = vnnproj.vnnnet[dnet].neuron[dnu].gridPos.Y;
                    DrawConnection(x1, y1, x2, y2, Pens.CadetBlue);
                }
            }
        }
        //**********************************************************        
        private void DrawConnection(int nx1, int ny1, int nx2, int ny2, Pen pen)
        {
            Bitmap b = (Bitmap)pictureBox2.Image;
            Graphics g = Graphics.FromImage(b);
            g.DrawLine(pen, nx1 * gx + gx / 2, ny1 * gy + gy / 2, nx2 * gx + gx / 2, ny2 * gy + gy / 2);
            g.Dispose();
            pictureBox2.Image = b;
        }
        //**********************************************************        
        private void DrawInputNeuron(int nx, int ny, Pen pen)
        {
            Bitmap b = (Bitmap)pictureBox2.Image;
            Graphics g = Graphics.FromImage(b);
            g.DrawEllipse(pen, new Rectangle(nx * gx + gx / 4, ny * gy + gy / 4, gx / 2, gy / 2));
            g.DrawLine(pen, nx * gx + gx / 2, ny * gy + gy / 2, nx * gx + gx / 5, ny * gy + gy / 5);
            g.DrawLine(pen, nx * gx + gx / 2, ny * gy + gy / 2, nx * gx + gx / 5, ny * gy + gy * 4 / 5);
            g.DrawLine(pen, nx * gx + gx / 5, ny * gy + gy / 5, nx * gx + gx / 5, ny * gy + gy * 4 / 5);
            g.Dispose();
            pictureBox2.Image = b;
        }
        //**********************************************************        
        private void DrawHiddenNeuron(int nx, int ny, Pen pen)
        {
            Bitmap b = (Bitmap)pictureBox2.Image;
            Graphics g = Graphics.FromImage(b);
            g.DrawEllipse(pen, new Rectangle(nx * gx + gx / 4, ny * gy + gy / 4, gx / 2, gy / 2));
            g.Dispose();
            pictureBox2.Image = b;
        }
        //**********************************************************        
        private void DrawOutputNeuron(int nx, int ny, Pen pen)
        {
            Bitmap b = (Bitmap)pictureBox2.Image;
            Graphics g = Graphics.FromImage(b);
            g.DrawEllipse(pen, new Rectangle(nx * gx + gx / 4, ny * gy + gy / 4, gx / 2, gy / 2));
            g.DrawLine(pen, nx * gx + gx * 7 / 8, ny * gy + gy / 2, nx * gx + gx / 2, ny * gy + gy / 5);
            g.DrawLine(pen, nx * gx + gx * 7 / 8, ny * gy + gy / 2, nx * gx + gx / 2, ny * gy + gy * 4 / 5);
            g.DrawLine(pen, nx * gx + gx / 2, ny * gy + gy / 5, nx * gx + gx / 2, ny * gy + gy * 4 / 5);
            g.Dispose();
            pictureBox2.Image = b;
        }
        //**********************************************************
        public void InitializeNeuronsPosition2()
        {
            // grdMap = new GridMap[gnx, gny];
            if (proj == null)
                return;
            if (proj.vnnnet == null)
                return;
            grdMap = new GridMap[gnx, gny];
            int[] lyrs = proj.vnnnet[proj.selNet].nuLayers;
            int mx = lyrs.Length;
            int my = 0;
            for (int i = 0; i < lyrs.Length; i++)
            {
                if (my < lyrs[i])
                    my = lyrs[i];
            }
            short k = 0;
            for (int x = 0; x < lyrs.Length; x++)
            {
                int w = (my - lyrs[x]) / 2;
                for (int y = 0; y < lyrs[x]; y++)
                {
                    short x0 = (short)(magx + x * magx);
                    short y0 = (short)(magy + (y + w) * magy);
                    proj.vnnnet[proj.selNet].neuron[k].gridPos.X = x0;
                    proj.vnnnet[proj.selNet].neuron[k].gridPos.Y = y0;
                    grdMap[x0, y0].pos = (short)(k + 1);//none number 
                    grdMap[x0, y0].netno = (short)(proj.selNet + 1);
                    k++;
                }
            }
        }
        //*********************************************************
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDn = new Point(e.X, e.Y);
            nuNum = ShowNeuronProperty(e);
            PlotNetAll();
            tstxbxNuTyp.Text = nuNum.ToString();
            if (tsComboNu.SelectedIndex == (int)EditType.VIEW)
            {
                tstxbxNuTyp.Text = nuNum.ToString();
                int fno = (int)proj.vnnnet[0].neuron[nuNum - 1].funno;
                tstxbxNuTyp.Text = nuNum.ToString() + ": " + VnnBpLib.VnnBpNet.funName[fno];
            }
            if (tsComboNu.SelectedIndex == (int)EditType.FUN)
            {
                tstxbxNuTyp.Text = nuNum.ToString();
                if (nuNum > 0)
                {
                    int fno = (int)proj.vnnnet[0].neuron[nuNum - 1].funno;
                    tstxbxNuTyp.Text = nuNum.ToString() + ": " + VnnBpLib.VnnBpNet.funName[fno];
                }
            }
            if (tsComboNu.SelectedIndex == (int)EditType.DRAG)
            {
                nuNum--;
                DrawInputNeuron(e, Pens.LemonChiffon);
                DrawOutputNeuron(e, Pens.LemonChiffon);
            }
            this.Cursor = Cursors.Hand;

        }
        //*********************************************************
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {

        }
        //*********************************************************
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (tsComboNu.SelectedIndex == (int)EditType.DRAG)
            {
                if (nuNum >= 0)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        vnnproj.vnnnet[vnnproj.selNet].neuron[nuNum].gridPos.X = (short)(((e.X / gx) / magx) * magx);
                        vnnproj.vnnnet[vnnproj.selNet].neuron[nuNum].gridPos.Y = (short)(((e.Y / gy) / magy) * magy);
                        //InitializeNeuronsPosition2();
                    }
                    if (e.Button == MouseButtons.Right)
                    {
                        int dx = e.X - mouseDn.X;
                        int dy = e.Y - mouseDn.Y;
                        for (int i = 0; i < vnnproj.vnnnet[vnnproj.selNet].neuron.Length; i++)
                        {
                            vnnproj.vnnnet[vnnproj.selNet].neuron[i].gridPos.X += (short)(((dx / gx) / magx) * magx);
                            vnnproj.vnnnet[vnnproj.selNet].neuron[i].gridPos.Y += (short)(((dy / gy) / magy) * magy);
                            // InitializeNeuronsPosition2();
                        }
                    }
                    //editType = EditType.NetUpdate;
                    grdMap = new GridMap[gnx, gny];
                    PlotNetAll();
                    proj.vnnnet[thisNet].UpdateNet();
                }
            }
            if (tsComboNu.SelectedIndex == (int)EditType.FUN)
            {
                tstxbxNuTyp.Text = nuNum.ToString();
                if (nuNum > 0)
                {
                    proj.vnnnet[0].neuron[nuNum - 1].funno = (short)tsComboNuFun.SelectedIndex;
                    tstxbxNuTyp.Text = nuNum.ToString() + ": " + VnnBpLib.VnnBpNet.funName[proj.vnnnet[0].neuron[nuNum - 1].funno];
                    InitializeNeuronsPosition2();
                    PlotNetAll();
                }
            }
            this.Cursor = Cursors.Arrow;
        }
        //**********************************************************        
        private short ShowNeuronProperty(MouseEventArgs e)
        {
            string[] nuTypNm = new string[] { "none", "in", "out", "hdn" };
            int nx = (e.X / gx);// / magx;
            int ny = (e.Y / gy);// / magy;
            short nuno = grdMap[nx, ny].pos;
            vnnproj.selNet = 0;
            short netno = (short)(vnnproj.selNet + 1);
            string st1 = "(" + nx.ToString() + "," + ny.ToString() + ") " + nuno.ToString() + " NetNo:" + netno.ToString();
            //toolStatusInfo.Text = st1;
            return nuno;
        }
        //**********************************************************        
        private void DrawInputNeuron(MouseEventArgs e, Pen pen)
        {
            int nx = (e.X / gx) / magx * magx;
            int ny = (e.Y / gy) / magy * magy;
            //if (pos[nx, ny] != 0)
            if (grdMap[nx, ny].pos != 0)
            {
                // SystemSounds.Asterisk.Play();
                return;
            }
            grdMap[nx, ny].pos = -(short)VnnBpLib.NuType.In;
            grdMap[nx, ny].netno = (short)(vnnproj.selNet + 1);//??
            Bitmap b = (Bitmap)pictureBox1.Image;
            Graphics g = Graphics.FromImage(b);
            g.DrawEllipse(pen, new Rectangle(nx * gx + gx / 4, ny * gy + gy / 4, gx / 2, gy / 2));
            g.DrawLine(pen, nx * gx + gx / 2, ny * gy + gy / 2, nx * gx + gx / 5, ny * gy + gy / 5);
            g.DrawLine(pen, nx * gx + gx / 2, ny * gy + gy / 2, nx * gx + gx / 5, ny * gy + gy * 4 / 5);
            g.DrawLine(pen, nx * gx + gx / 5, ny * gy + gy / 5, nx * gx + gx / 5, ny * gy + gy * 4 / 5);
            g.Dispose();
            pictureBox1.Image = b;
        }
        //**********************************************************        
        private void DrawOutputNeuron(MouseEventArgs e, Pen pen)
        {
            //int nx = e.X / gx;
            //int ny = e.Y / gy;
            int nx = (e.X / gx) / magx * magx;
            int ny = (e.Y / gy) / magy * magy;
            if (grdMap[nx, ny].pos != 0)
            {
                //SystemSounds.Asterisk.Play();
                return;
            }
            grdMap[nx, ny].pos = -(short)VnnBpLib.NuType.Out;
            grdMap[nx, ny].netno = (short)(vnnproj.selNet + 1);//??
            Bitmap b = (Bitmap)pictureBox1.Image;
            Graphics g = Graphics.FromImage(b);
            g.DrawEllipse(pen, new Rectangle(nx * gx + gx / 4, ny * gy + gy / 4, gx / 2, gy / 2));
            g.DrawLine(pen, nx * gx + gx * 7 / 8, ny * gy + gy / 2, nx * gx + gx / 2, ny * gy + gy / 5);
            g.DrawLine(pen, nx * gx + gx * 7 / 8, ny * gy + gy / 2, nx * gx + gx / 2, ny * gy + gy * 4 / 5);
            g.DrawLine(pen, nx * gx + gx / 2, ny * gy + gy / 5, nx * gx + gx / 2, ny * gy + gy * 4 / 5);
            g.Dispose();
            pictureBox1.Image = b;
        }
        //**********************************************************
        private void tsComboNu_Click(object sender, EventArgs e)
        {
            //if (tsComboNu.SelectedIndex == 2)//Fun
            //{
            //    tsComboNuFun.Visible = true;
            //}
            //else
            //{
            //    tsComboNuFun.Visible = false;
            //}
        }
        //**********************************************************
        private void btnOptimizeNeuronPosition_Click(object sender, EventArgs e)
        {
            int netNo = 0;
            int[] lyrs = vnnproj.vnnnet[netNo].nuLayers;
            int[][] tbl = new int[0][];
            for (int n = 0; n < vnnproj.vnnnet[netNo].maxNeurons; n++)
            {
                int lno = vnnproj.vnnnet[netNo].neuron[n].netpos.lyrno;
                int rno = vnnproj.vnnnet[netNo].neuron[n].netpos.rowno;
            }


            float conLen = GetConnectionLength();
            tstxbxNuTyp.Text = ((int)conLen).ToString();
        }
        //**********************************************************
        private float GetConnectionLength()
        {
            int netNo = 0;
            float sum = 0;
            for (int n = 0; n < vnnproj.vnnnet[netNo].maxConnections; n++) //for (int n = 0; n < vnnproj.vnnnet[netNo].conn.Length; n++)
            {
                int sn = vnnproj.vnnnet[netNo].conn[n].srcNuNo;
                int dn = vnnproj.vnnnet[netNo].conn[n].dstNuNo;
                int x1 = vnnproj.vnnnet[netNo].neuron[sn].gridPos.X;
                int y1 = vnnproj.vnnnet[netNo].neuron[sn].gridPos.Y;
                int x2 = vnnproj.vnnnet[netNo].neuron[dn].gridPos.X;
                int y2 = vnnproj.vnnnet[netNo].neuron[dn].gridPos.Y;
                float dist = DistanceP1P2(x1, y1, x2, y2);
                sum += dist;
            }

            return sum;
        }
        //*********************************************************
        private float DistanceP1P2(float x1, float y1, float x2, float y2)
        {
            float dist = (float)Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            return dist;
        }
        //*********************************************************
        private void tsComboNu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tsComboNu.SelectedIndex == 2)//Fun
            {
                tsComboNuFun.Visible = true;
            }
            else
            {
                tsComboNuFun.Visible = false;
            }
        }
        //*********************************************************
    }
}