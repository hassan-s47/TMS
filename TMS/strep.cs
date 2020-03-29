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
    public partial class strep : Form
    {
        DataSet ds1=new DataSet();
       
        public strep(DataSet ds)
        {
            
            ds1 = ds;
            InitializeComponent();

        }

        private void strep_Load(object sender, EventArgs e)
        {

            try
            {
                delablerpt cr = new delablerpt();
                cr.SetDataSource(ds1);
                crystalReportViewer1.ReportSource = cr;
            }
            catch (Exception x)
            {

                MessageBox.Show(x.ToString());
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
