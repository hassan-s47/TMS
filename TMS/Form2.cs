using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMS
{
    public partial class Form2 : Form
    {
        DataSet ds;
        public Form2(DataSet sd)
        {
            ds = sd;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           stockrepcr mp = new stockrepcr();
            mp.SetDataSource(ds);
            crystalReportViewer1.ReportSource = mp;
        }
    }
}
