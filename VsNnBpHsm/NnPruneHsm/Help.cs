using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VnnBp
{
    public partial class HelpDoc : Form
    {
        //**********************************************************
        String flnm = "Help.rtf";
        //**********************************************************
        public HelpDoc()
        {
            InitializeComponent();
        }
        //**********************************************************
        private void HelpDoc_Shown(object sender, EventArgs e)
        {
            LoadMyFile();
        }
        //**********************************************************
        public void SaveMyFile()
        {
            richTextBox1.SaveFile(flnm, RichTextBoxStreamType.RichText);
        }
        //**********************************************************
        public void LoadMyFile()
        {
            if (File.Exists(flnm))
                richTextBox1.LoadFile(flnm, RichTextBoxStreamType.RichText);
        }
        //**********************************************************
        public void SaveMyFileFull()
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.RichText);
            }
        }
        //**********************************************************
        public void LoadMyFileFull()
        {
            OpenFileDialog openFile1 = new OpenFileDialog();
            openFile1.DefaultExt = "*.rtf";
            openFile1.Filter = "RTF Files|*.rtf";
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                richTextBox1.LoadFile(openFile1.FileName, RichTextBoxStreamType.RichText);
            }
        }
        //**********************************************************
    }
}