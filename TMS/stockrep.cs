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
    public partial class stockrep : Form
    {
        public stockrep()
        {
            InitializeComponent();
        }

        private void stockrep_Load(object sender, EventArgs e)
        {
            db log=new TMS.db();
            string query = "select * from stockrep ";
            log.open();
          BindingSource bs=  log.Select_Query(query);
            dataGridView1.DataSource = bs;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            db log = new TMS.db();
            string query = "select * from stockrep ";
            log.open();
            BindingSource bs = log.Select_Query(query);
            dataGridView1.DataSource = bs;
        }

        private void button3_Click(object sender, EventArgs e)
        {
       
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("pcode", typeof(string));
            dt.Columns.Add("Pname", typeof(string));
            dt.Columns.Add("kg", typeof(Int32));
            dt.Columns.Add("bag", typeof(Int32));
           dt.Columns.Add("pc", typeof(Int32));
            
            
            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("makefile.xml");
           

           //stockrepcr r= new stockrepcr(ds);
           Form2 r = new Form2(ds);
           r.Show();

          
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void stockrep_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
        }
    }
}
