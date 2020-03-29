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
    public partial class partylegprint : Form
    {
        DataSet ds = new DataSet();
        public partylegprint(DataSet sd)
        {
            ds = sd;
            InitializeComponent();
        }

        private void partylegprint_Load(object sender, EventArgs e)
        {
            partylegrep cr = new partylegrep();
             cr.SetDataSource(ds);
               crystalReportViewer1.ReportSource = cr;
        }
    }
}
