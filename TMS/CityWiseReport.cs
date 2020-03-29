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
    public partial class CityWiseReport : Form
    {
        public CityWiseReport()
        {
            InitializeComponent();
        }
        DataTable read;

        private void CityWiseReport_Load(object sender, EventArgs e)
        {
            string query = "select city,sum(balance) as amount from party group by city";
            db log = new db();
            log.open();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            read = log.searchquery(query);
            log.close();
            if(read.Rows.Count!=0)
            {
                for(int i=0;i<read.Rows.Count;i++)
                {
                    dataGridView1.Rows.Add(1);
                    dataGridView1[0, i].Value = read.Rows[i][0].ToString();
                    dataGridView1[1, i].Value = read.Rows[i][1].ToString();


                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            int rcounter = 0;
            for (int i = 0; i < read.Rows.Count; i++)
            {
                if (read.Rows[i][0].ToString().Contains(s))
                {
                    dataGridView1.Rows.Add(1);
                    dataGridView1[0, rcounter].Value = read.Rows[i][0].ToString();
                    dataGridView1[1, rcounter].Value = read.Rows[i][1].ToString();
                    rcounter++;
                }
            }

        }
    }
}
