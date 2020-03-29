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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            partyform pf = new partyform();
            pf.Show();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            productformcs pr = new productformcs();
            pr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            salevoucher sv = new salevoucher();
            sv.Show();
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            purchasevoucher pv = new purchasevoucher();
            pv.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            cpvoucher cp = new cpvoucher();
            cp.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            crvoucher cr = new crvoucher();
            cr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ledgerinput l = new ledgerinput();
            l.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            stockrep sr = new stockrep();
            sr.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
           SaleReport sr = new SaleReport();
            //Form3 sr = new Form3();
            sr.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            CityWiseReport s = new CityWiseReport();
            s.Show();
        }
    }
}
