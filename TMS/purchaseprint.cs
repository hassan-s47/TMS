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
    public partial class purchaseprint : Form
    {
        DataSet ds;
        public purchaseprint(DataSet sd)
        {
            ds=sd;
            InitializeComponent();

        }

        private void purchaseprint_Load(object sender, EventArgs e)
        {
            PurchaseVouchercr cr = new PurchaseVouchercr();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
