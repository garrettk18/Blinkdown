using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blinkdown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string MdHtml = CommonMark.CommonMarkConverter.Convert(textBox1.Text);
            webBrowser1.Document.OpenNew(false);
            webBrowser1.Document.Write(MdHtml);
        }
    }
}
