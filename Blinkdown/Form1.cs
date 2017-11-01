using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Blinkdown
{
    public partial class Form1 : Form
    {
        private string _fileName;
        private bool _modified;

        public Form1()
        {
            InitializeComponent();
            _fileName = "";
            if (_fileName == "")
            {
             this.Text = "Untitled - " + Text;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!_modified)
            {
                _modified = true;
                Text = "*" + Text;
            }
            string MdHtml = CommonMark.CommonMarkConverter.Convert(textBox1.Text);
            webBrowser1.Document.OpenNew(false);
            webBrowser1.Document.Write(MdHtml);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            using (StreamReader InputFile = new StreamReader(openFileDialog1.FileName))
            {
                string InputText = InputFile.ReadToEnd();
                textBox1.Text = InputText;
                Text = openFileDialog1.FileName + " - Blinkdown";
                webBrowser1.Document.Title = openFileDialog1.FileName;
                _fileName = openFileDialog1.FileName;
                _modified = false;
            }
        }
    }
}
