﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


namespace TMS
{
    public partial class saleprint : Form
    {
        DataSet ds;
        public saleprint(DataSet sd)
        {
            ds = sd;
            InitializeComponent();
        }

        private void saleprint_Load(object sender, EventArgs e)
        {
            SaleVouchercr cr = new SaleVouchercr();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
