using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SoSlow
{
    public partial class ReportLog : Form
    {
        public string content;

        public void UpdateContent(string log)
        {
            reportContent.Text = log;
        }

        public ReportLog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
