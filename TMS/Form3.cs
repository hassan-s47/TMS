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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            DataTable t = new DataTable();
            t.Columns.Add("id", typeof(Int16));
            t.Columns.Add("name", typeof(string));
            t.Columns.Add("family", typeof(string));
            //add data to table
            t.Rows.Add(1, "hasan", "amiri");
            t.Rows.Add(2, "reza", "amiri");
            t.Rows.Add(3, "amin", "neisi");

            //bind table to datagridview
            dataGridView1.DataSource = t;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(Int16));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("family", typeof(string));
            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2]);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("testfile.xml");

            Form2 f = new Form2(ds);
            f.Show();
        }
    }
}
